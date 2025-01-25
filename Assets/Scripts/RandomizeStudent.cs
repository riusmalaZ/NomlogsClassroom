using System.Collections.Generic;
using UnityEngine;

public class RandomizeStudent : MonoBehaviour
{
    [Header("Colors")]
    public List<Color> SkinColors = new List<Color>();
    public List<Color> OutfitColors = new List<Color>();
    [Header("Prefabs")]
    public GameObject GumPrefab;
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
        string sortingLayerNameRow = "FirstRow";
        switch(GetComponent<Student>().Row){
            case 1:
                sortingLayerNameRow = "FirstRow";
                break;
            case 2:
                sortingLayerNameRow = "SecondRow";
                break;
            case 3:
                sortingLayerNameRow = "ThirdRow";
                break;
            case 4:
                sortingLayerNameRow = "FourthRow";
                break;
        }
        GameObject body = Instantiate(BodyPrefab[Random.Range(0, BodyPrefab.Count)],transform);
        body.GetComponent<SpriteRenderer>().color = OutfitColors[Random.Range(0,OutfitColors.Count)];
        body.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerNameRow;
        GameObject headShape = Instantiate(HeadShapePrefab[Random.Range(0, HeadShapePrefab.Count)],body.transform.GetChild(0));
        headShape.GetComponent<SpriteRenderer>().color = SkinColors[Random.Range(0,SkinColors.Count)];
        headShape.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerNameRow;

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

        GameObject hair = Instantiate(HairPrefab[Random.Range(0, HairPrefab.Count)],headShape.transform.GetChild(indexHairPos));
        hair.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerNameRow;
        int j = Random.Range(-2, GlassesPrefab.Count);
        if(j >= 0){
            GameObject glasses = Instantiate(GlassesPrefab[j],headShape.transform.GetChild(indexGlassesPos));
            glasses.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerNameRow;
        }
        GameObject eyes = Instantiate(EyesPrefab[Random.Range(0, EyesPrefab.Count)],headShape.transform.GetChild(indexEyesPos));
        eyes.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerNameRow;
        GameObject mouthAndNose = Instantiate(MouthAndNosePrefab[Random.Range(0, MouthAndNosePrefab.Count)],headShape.transform.GetChild(indexMouthPos));
        mouthAndNose.GetComponent<SpriteRenderer>().color = headShape.GetComponent<SpriteRenderer>().color;
        mouthAndNose.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerNameRow;
        GameObject gum = Instantiate(GumPrefab,headShape.transform.GetChild(indexMouthPos));
        gum.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerNameRow;
    }
}
