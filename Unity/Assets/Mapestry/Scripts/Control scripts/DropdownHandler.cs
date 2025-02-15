using System;
using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapestryExchangers;
using Mapestry.Models;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;

namespace MapestryControls
{

    class DropdownHandler : MonoBehaviour
    {
        public TMP_Text chosenOption;

        async void Start(){

            ListHunts(await HuntExchanger.UpdateHunts());
        }

        void ListHunts(List<Hunt> hunts) {

            var dropdown = transform.GetComponent<TMP_Dropdown>();
            
            foreach(var hunt in hunts){
                dropdown.options.Add(new TMP_Dropdown.OptionData(hunt.HuntName+"/"+hunt.UserName));
            }

            DropdownItemSelected(dropdown);
            dropdown.onValueChanged.AddListener(delegate {DropdownItemSelected(dropdown);});
        }

        void DropdownItemSelected(TMP_Dropdown dropdown){

            int index = dropdown.value;
            Debug.LogError("Before the split");
            string[] chosenValue = dropdown.options[index].text.Split('/');
            string chosenHuntName = chosenValue[0];
            Debug.LogError("After hunt name");
            string chosenHuntCreator = chosenValue[1];
            Debug.LogError("After hunt creator");
            HuntExchanger.pickedHunt = null;
            Debug.LogError("Is hunts empty: "+HuntExchanger.hunts[0].HuntName.ToString());

            foreach(var hunt in HuntExchanger.hunts){
                if(hunt.HuntName == chosenHuntName && hunt.UserName == chosenHuntCreator)
                {
                    HuntExchanger.pickedHunt = hunt;
                    dropdown.captionText.text = hunt.HuntName;
                    chosenOption.text = "Hunt Description: "+ hunt.HuntDescription;
                    Debug.LogError("Picked hunt is: "+HuntExchanger.pickedHunt.HuntName);
                    break;
                }
            }

            if(HuntExchanger.pickedHunt == null)
            {
                Debug.LogError("This hunt could not be found.");
                chosenOption.text = "Hunt could not be found!";
            }
        }
    }
}
