using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static Dictionary<string, Queue<GameObject>> g_poolDictionary = new Dictionary<string, Queue<GameObject>>();

    public static GameObject Get(GameObject argGameObject)
    {
        if (g_poolDictionary.TryGetValue(argGameObject.name, out Queue<GameObject> _poolList))
        {
            if (_poolList.Count == 0)
            {
                // ���� �����
                return CreateNewObject(argGameObject);
            }
            else
            {
                GameObject _obj = _poolList.Dequeue();
                _obj.gameObject.SetActive(true);

                return _obj;
            }
        }
        else
        {
            return CreateNewObject(argGameObject);
        }
    }

    /// <summary>
    /// ���� ���� ���
    /// </summary>
    /// <param name="argGameObject">���� �� ������Ʈ</param>
    /// <returns>���� �� ������Ʈ</returns>
    private static GameObject CreateNewObject(GameObject argGameObject)
    {
        GameObject _obj = Instantiate(argGameObject);
        _obj.name = argGameObject.name;
        _obj.transform.parent = GameObject.Find($"{_obj.name}Pool").transform;
        return _obj;
    }

    public static void Return(GameObject argGameObject)
    {
        if (g_poolDictionary.TryGetValue(argGameObject.name, out Queue<GameObject> _poolList))
        {
            _poolList.Enqueue(argGameObject);
        }
        else
        {
            Queue<GameObject> _newQueue = new Queue<GameObject>();
            _newQueue.Enqueue(argGameObject);
            g_poolDictionary.Add(argGameObject.name, _newQueue);
        }

        argGameObject.SetActive(false);
    }

    /// <summary>
    /// ó�� ���� ���� �� ������ �θ� �����
    /// </summary>
    /// <param name="argGameObjectName">�̸�</param>
    static void CreateParent(string argGameObjectName)
    {
        // ���߿� �������� ó�� ȹ�� �� �� ����
        GameObject _obj = new GameObject();
        _obj.name = argGameObjectName + "Pool";
        _obj.transform.parent = GameObject.Find("PoolManager").transform;
    }
}
