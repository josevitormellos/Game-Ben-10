using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnNave : MonoBehaviour
{
    public List<Image> nave;
    public List<Sprite> navePele;
    public List<GameObject> naveObject;
    public List<int> chaveDificuldade;
    // Start is called before the first frame update
    void Start()
    {
        SpawnNaveGalaxy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnNaveGalaxy(){
        int random;
        for(int i = 0; i < 3; i++){
            random = Random.Range(0, (10 + 10 * i));
            Debug.Log(random);

            if(random < 3){
                random = Random.Range(0, 100);
                naveObject[i].SetActive(true);
                if( random <= 70){
                    
                    nave[i].sprite = navePele[0];
                    chaveDificuldade[i] = 5;
                }
                else if( random <= 90){
                    nave[i].sprite = navePele[1];
                    chaveDificuldade[i] = 6;
                }
                else{
                    nave[i].sprite = navePele[2];
                    chaveDificuldade[i] = 7;
                }
            }
            else{
                naveObject[i].SetActive(false);
            }

        }
        random = Random.Range(0, 100);

        if(random < 50){
            naveObject[naveObject.Count - 1].SetActive(true);
            
        }
        
    }

    public void StatusDescriptions(int i){
        MenuStatusPlanet.instance.StatusDescriptions(chaveDificuldade[i]);
        PlayerPrefs.SetInt("NivelNaveDrop", i + 1);
    }


}
