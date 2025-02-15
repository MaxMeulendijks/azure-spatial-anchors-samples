
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mapestry.Models
{

    public class Hunt
    {
        public string UserName {get; set;}
        public string HuntName{get; set;}
        public string HuntDescription{get; set;}
        public bool IsPublic {get; set;}
        #nullable enable
        public string? UserNameNavigation {get; set;}
        List<string>? HuntAnchors {get; set;}
        List<string>? PlayerHunts {get; set;}
        #nullable disable

        public Hunt()
        {

        }

        public Hunt(string huntName, string userName)
        {
            HuntName = huntName;
            UserName = userName;
        }

        #nullable enable
        public Hunt(string huntName, string userName, string? huntDescription, int? isPublic, string? userNameNavigation, List<string>? huntAnchors, List<string>? playerHunts)
        {
        #nullable disable
            HuntName = huntName;
            UserName = userName;
            HuntDescription = huntDescription;
            if(isPublic == 1)
            {
                IsPublic = true;
            } 
            else 
            {
                IsPublic = false;
            }

            UserNameNavigation = userNameNavigation;
            HuntAnchors = huntAnchors;
            PlayerHunts = playerHunts;
        }

    }
       
}

