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
                // 새로 만들기
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
    /// 새로 만들 경우
    /// </summary>
    /// <param name="argGameObject">생성 할 오브젝트</param>
    /// <returns>생성 한 오브젝트</returns>
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
    /// 처음 생성 했을 때 정리용 부모 만들기
    /// </summary>
    /// <param name="argGameObjectName">이름</param>
    static void CreateParent(string argGameObjectName)
    {
        // 나중에 아이템을 처음 획득 할 때 실행
        GameObject _obj = new GameObject();
        _obj.name = argGameObjectName + "Pool";
        _obj.transform.parent = GameObject.Find("PoolManager").transform;
    }
}
