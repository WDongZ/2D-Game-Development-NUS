using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffHandler : MonoBehaviour
{
    public LinkedList<BuffInfo> buffList = new LinkedList<BuffInfo>();

    void Update()
    {
        BuffTickAndRemove();
    }
    private void BuffTickAndRemove()
    {
        List<BuffInfo> deletedBuffList = new List<BuffInfo>();
        foreach (var buffInfo in buffList)
        {
            if(buffInfo.buffData.OnTick!=null)
            {
                if(buffInfo.tickRate < 0)
                {
                    buffInfo.buffData.OnTick.Apply(buffInfo);
                    buffInfo.tickRate = buffInfo.buffData.tickRate;
                }
                else
                {
                    buffInfo.tickRate -= Time.deltaTime;
                }
            }
            if(!buffInfo.buffData.isForever)
            {
                if(buffInfo.duration < 0)
                {
                    deletedBuffList.Add(buffInfo);
                }
                else
                {
                    buffInfo.duration -= Time.deltaTime;
                }
            }
        }
        foreach (var buffInfo in deletedBuffList)
        {
            RemoveBuff(buffInfo);
        }
    }

    public void AddBuff(BuffInfo buffInfo)
    {
        BuffInfo findingBuffInfo = FindBuff(buffInfo.buffData.id);
        if(findingBuffInfo != null)
        {
            if(findingBuffInfo.buffData.maxStack > findingBuffInfo.curStack)
            {
                findingBuffInfo.curStack++;
                switch(buffInfo.buffData.buffUpdateTime)
                {
                    case BuffUpdateTimeEnum.Add:
                        findingBuffInfo.duration += findingBuffInfo.buffData.duration;
                        break;
                    case BuffUpdateTimeEnum.Replace:
                        findingBuffInfo.duration = findingBuffInfo.buffData.duration;
                        break;
                    case BuffUpdateTimeEnum.Keep:
                        break;
                }
                findingBuffInfo.buffData.OnCreate.Apply(findingBuffInfo);
            }
        }
        else
        {
            buffInfo.duration = buffInfo.buffData.duration;
            buffInfo.buffData.OnCreate.Apply(buffInfo);
            buffList.AddLast(buffInfo);

            //排序
            InsertionSortLinkedList(buffList);

        }
    }
    public void RemoveBuff(BuffInfo buffInfo)
    {
        switch (buffInfo.buffData.buffRemoveUpdate)
        {
            case BuffRemoveUpdateEnum.Clear:
                buffInfo.buffData.OnRemove.Apply(buffInfo);
                buffList.Remove(buffInfo);
                break;
            case BuffRemoveUpdateEnum.Reduce:
                buffInfo.curStack--;
                buffInfo.buffData.OnRemove.Apply(buffInfo);
                if(buffInfo.curStack == 0)
                {
                    buffList.Remove(buffInfo);
                }
                else
                {
                    buffInfo.duration = buffInfo.buffData.duration;
                }
                break;
        }
    }

    private BuffInfo FindBuff(int buffDataId)
    {
        foreach (var buffInfo in buffList)
        {
            if (buffInfo.buffData.id == buffDataId)
            {
                return buffInfo;
            }
        }
        return default;
    }

    void InsertionSortLinkedList(LinkedList<BuffInfo> list)//AI
    {
    if (list == null || list.First == null)
        return;

    LinkedListNode<BuffInfo> current = list.First.Next;

    while (current != null)
    {
        LinkedListNode<BuffInfo> next = current.Next;
        LinkedListNode<BuffInfo> prev = current.Previous;

        while (prev != null && prev.Value.buffData.priority > current.Value.buffData.priority)
        {
            prev = prev.Previous;
        }

        if (prev == null)
        {
            // current是当前最高优先级的节点
            list.Remove(current);
            list.AddFirst(current);
        }
        else
        {
            // current插入到prev之后
            list.Remove(current);
            list.AddAfter(prev, current);
        }

        current = next;
    }
    }

}
