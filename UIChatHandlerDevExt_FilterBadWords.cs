using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MultiplayerARPG
{    public partial class UIChatHandler : UIBase
    {

        [Category("Filter Bad Words")]
        [Header("Filter Bad Words")]
        [Tooltip("Replace each character of bad word with this CHARACTER")]
        [SerializeField]        protected string replaceBadWordWith = "*";
        [Tooltip("List of words to be filter")]
        [SerializeField]        protected List<string> filterWordsList = new List<string>();

        //For UnityEditor use only
        [Tooltip("Editor tool to fill the FilterWordsList quickly using a string-list of words separated by newline. Please use carefully.")]
        [SerializeField] [TextArea(10,20)] protected string fillFilterListWith;

        /// <summary>
        /// FilterBadWords from the _message text using the filterWordsList and replace with bad word character.
        /// </summary>
        /// <param name="_message"></param>
        /// <returns></returns>
        /// Call this method in UIChatHandler.cs from OnReceiveChat()
        protected ChatMessage FilterBadWords(ChatMessage _message)
        {
            //Only execute if we have words to filter, else return back original message as it is
            if(filterWordsList.Count > 0)
            {
                foreach (string fWord in filterWordsList)
                {
                    if (fWord.Trim() != "")
                    {
                        //  Replace the word with replaceBadWordWith (but keep it the same length)
                        string strReplace = "";
                        for (int i = 0; i <= fWord.Length; i++)
                        {
                            strReplace += replaceBadWordWith;
                        }
                        _message.message = Regex.Replace(_message.message, fWord, strReplace, RegexOptions.IgnoreCase);
                    }
                }
                return _message;
            }
            return _message;
        }


        /// <summary>
        /// Fill the FilterWordsList using the fillFilterListWith string which is separated by newlines (\n)
        //  Using this list - https://github.com/LDNOOBW/List-of-Dirty-Naughty-Obscene-and-Otherwise-Bad-Words/blob/master/en
        //  Should be atleast more than 5 words, else just enter tham manually in the FilterWordsList
        //  Will append the FilterWordsList, not clear it
        /// </summary>
#if UNITY_EDITOR
        private void OnValidate()
        {
            if(fillFilterListWith.Trim() != "")
            {
                string[] _stringArray = fillFilterListWith.Split("\n");
                if(_stringArray.Length > 4)
                {
                    foreach(string input in _stringArray)
                    {
                        if (input.Trim() != "")
                        {
                            filterWordsList.Add(input.Trim());
                        }
                    }
                    //Clear after processing
                    fillFilterListWith = "";
                }
            }
        }
#endif
    }
}