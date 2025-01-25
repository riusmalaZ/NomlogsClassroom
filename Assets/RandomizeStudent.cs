using System.Collections.Generic;
using UnityEngine;

public class RandomizeStudent : MonoBehaviour
{
    public List<GameObject> BodyPrefab = new List<GameObject>();
    public List<GameObject> HeadShapePrefab = new List<GameObject>();
    public List<GameObject> HairPrefab = new List<GameObject>();
    public List<GameObject> MouthAndNosePrefab = new List<GameObject>();
    public List<GameObject> EyesPrefab = new List<GameObject>();
    public List<GameObject> GlassesPrefab = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _randomizeAppearance();
    }

    private void _randomizeAppearance(){
        GameObject body = Instantiate(BodyPrefab[Random.Range(0, BodyPrefab.Count)],transform);
        GameObject headShape = Instantiate(HeadShapePrefab[Random.Range(0, HeadShapePrefab.Count)],body.transform.GetChild(0));
        int indexHairPos = 0, indexMouthPos = 0, indexGlassesPos = 0, indexEyesPos = 0;
        for(int i = 0; i < headShape.transform.childCount; i++){
            switch(headShape.transform.GetChild(i).name){
                case "HairPosition":
                    indexHairPos = i;
                    break;
                case "MouthAndNosePosition":
                    indexMouthPos = i;
                    break;
                case "EyesPosition":
                    indexEyesPos = i;
                    break;
                case "GlassesPosition":
                    indexGlassesPos = i;
                    break;
            }
        }
        Instantiate(HairPrefab[Random.Range(0, HairPrefab.Count)],headShape.transform.GetChild(indexHairPos));
        int j = Random.Range(-2, GlassesPrefab.Count);
        if(j >= 0)
            Instantiate(GlassesPrefab[j],headShape.transform.GetChild(indexGlassesPos));
        Instantiate(EyesPrefab[Random.Range(0, EyesPrefab.Count)],headShape.transform.GetChild(indexEyesPos));
        Instantiate(MouthAndNosePrefab[Random.Range(0, MouthAndNosePrefab.Count)],headShape.transform.GetChild(indexMouthPos));
    }
}
