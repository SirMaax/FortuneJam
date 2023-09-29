using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceManager : MonoBehaviour
{
    [SerializeField]private List<MonoBehaviour> referenceList;
    [SerializeField]private List<GameObject> referenceListObject;
    [SerializeField] private Dictionary<RefEnum, MonoBehaviour> dictionary;
    [SerializeField] private Dictionary<RefEnumGame, GameObject> dictionaryObject;
    public static ReferenceManager referenceManager;
    
    public enum RefEnum
    {
        inputHandler,
        playerControl,
    }

    public enum RefEnumGame
    {
        player
    }
    // Start is called before the first frame update

    private void Awake()
    {
        referenceManager = this;
        
        dictionary = new Dictionary<RefEnum, MonoBehaviour>();
        dictionary.Add(0,referenceList[0]);
        dictionary.Add(RefEnum.playerControl,referenceList[1]);
        
        dictionaryObject = new Dictionary<RefEnumGame, GameObject>();
        dictionaryObject.Add(0,referenceListObject[0]);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public MonoBehaviour GiveRef(RefEnum reference)
    {
        if (dictionary.ContainsKey(reference)) return dictionary[reference];
        return null;
          
    }
    
    public GameObject GiveGame(RefEnumGame reference)
    {
        if (dictionaryObject.ContainsKey(reference)) return dictionaryObject[reference];
        return null;
          
    }
}
