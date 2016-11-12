﻿using UnityEngine;
using System.Collections;

public abstract class IInputEventBase 
{
    public float m_eventTime = 0;

    string m_eventKey;

    public IInputEventBase()
    {
        m_eventTime = Time.time;
    }

    public virtual string GetEventKey()
    {
        if (m_eventKey == null)
        {
            m_eventKey = ToString();
        }
        return m_eventKey;
    }

    /// <summary>
    /// 序列化，使一个输入事件变成可保存的文本
    /// </summary>
    /// <returns></returns>
    public virtual string Serialize()
    {
        return JsonUtility.ToJson(this);
    }

    /// <summary>
    /// 解析，将一个文本变成输入事件的数据
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static IInputEventBase Analysis(string data)
    {
        return JsonUtility.FromJson<IInputEventBase>(data);
    }
}
