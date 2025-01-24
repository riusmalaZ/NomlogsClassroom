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
        GameObject headShape = Instantiate(HeadShapePrefab[Random.Range(0, HeadShapePrefab.Count)]);
        headShape.transform.position = body.transform.GetChild(0).position;
        headShape.transform.SetParent(body.transform.GetChild(0),true);
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
        GameObject hair = Instantiate(HairPrefab[Random.Range(0, HairPrefab.Count)]);
        hair.transform.position = headShape.transform.GetChild(indexHairPos).position;
        hair.transform.SetParent(headShape.transform.GetChild(indexHairPos),true);
        GameObject glasses = Instantiate(GlassesPrefab[Random.Range(0, GlassesPrefab.Count)]);
        glasses.transform.position = headShape.transform.GetChild(indexGlassesPos).position;
        glasses.transform.SetParent(headShape.transform.GetChild(indexGlassesPos),true);
        GameObject eyes = Instantiate(EyesPrefab[Random.Range(0, EyesPrefab.Count)]);
        eyes.transform.position = headShape.transform.GetChild(indexEyesPos).position;
        eyes.transform.SetParent(headShape.transform.GetChild(indexEyesPos),true);
        GameObject mouthAndNose = Instantiate(MouthAndNosePrefab[Random.Range(0, MouthAndNosePrefab.Count)]);
        mouthAndNose.transform.position = headShape.transform.GetChild(indexMouthPos).position;
        mouthAndNose.transform.SetParent(headShape.transform.GetChild(indexMouthPos),true);
    }
}
