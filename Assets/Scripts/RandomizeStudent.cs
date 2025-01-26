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
    public List<GameObject> HeadColorPrefab = new List<GameObject>();
    public List<GameObject> HairPrefab = new List<GameObject>();
    public List<GameObject> MouthAndNosePrefab = new List<GameObject>();
    public List<GameObject> EyesPrefab = new List<GameObject>();
    public List<GameObject> GlassesPrefab = new List<GameObject>();
    public List<GameObject> LogosPrefab = new List<GameObject>();

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
        GameObject hood = body.transform.GetChild(2).gameObject;
        hood.GetComponent<SpriteRenderer>().color = body.GetComponent<SpriteRenderer>().color;
        hood.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerNameRow;
        GameObject headColor = Instantiate(HeadColorPrefab[Random.Range(0, HeadColorPrefab.Count)],body.transform.GetChild(0));
        headColor.GetComponent<SpriteRenderer>().color = SkinColors[Random.Range(0,SkinColors.Count)];
        headColor.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerNameRow;
        GameObject logo = Instantiate(LogosPrefab[Random.Range(0,LogosPrefab.Count)],body.transform.GetChild(1));
        logo.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerNameRow;
        for(int i = 0; i < body.transform.GetChild(3).childCount; i++){
            body.transform.GetChild(3).GetChild(i).GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerNameRow;
            body.transform.GetChild(3).GetChild(i).GetComponentInChildren<SpriteRenderer>().sortingLayerName = sortingLayerNameRow;
        }
        int indexHairPos = 0, indexMouthPos = 0, indexGlassesPos = 0, indexEyesPos = 0, indexHeadShape = 0;
        for(int i = 0; i < headColor.transform.childCount; i++){
            switch(headColor.transform.GetChild(i).name){
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
                case "HeadShape":
                    indexHeadShape = i;
                    break;
            }
        }

        GameObject headShape = headColor.transform.GetChild(indexHeadShape).gameObject;
        headShape.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerNameRow;
        GameObject hair = Instantiate(HairPrefab[Random.Range(0, HairPrefab.Count)],headColor.transform.GetChild(indexHairPos));
        hair.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerNameRow;
        int j = Random.Range(-2, GlassesPrefab.Count);
        if(j >= 0){
            GameObject glasses = Instantiate(GlassesPrefab[j],headColor.transform.GetChild(indexGlassesPos));
            glasses.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerNameRow;
        }
        GameObject eyes = Instantiate(EyesPrefab[Random.Range(0, EyesPrefab.Count)],headColor.transform.GetChild(indexEyesPos));
        eyes.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerNameRow;
        GameObject mouthAndNose = Instantiate(MouthAndNosePrefab[Random.Range(0, MouthAndNosePrefab.Count)],headColor.transform.GetChild(indexMouthPos));
        mouthAndNose.GetComponent<SpriteRenderer>().color = headColor.GetComponent<SpriteRenderer>().color;
        mouthAndNose.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerNameRow;
        GameObject gum = Instantiate(GumPrefab,headColor.transform.GetChild(indexMouthPos));
        GetComponent<Student>().animator = gum.GetComponent<Animator>();
        gum.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerNameRow;
        
    }
}
