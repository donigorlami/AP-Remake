using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Human.HumanDatabase;

namespace Human
{
    public class humangenerator : MonoBehaviour
    {
        void Start()
        {
            //get a human 
            generateHuman();
        }
        void Update()
        {
            //generateHuman();
            if (Input.GetKeyUp(KeyCode.X))
            {
                generateHuman();
            }
        }


        void generateHuman()
        {
            human randomHuman = new human();
            for (int i = 0; i < randomHuman.sins.Length; i++)
            {
                Debug.Log(randomHuman.sins[i]);
            }
        }
    }

    class human
    {
        public char gender;
        public string name;
        public string surname;
        enum personality
        {
            ExtremeSinner, Sinner, Neutral, Saint, ExtremeSaint
        }
        personality humanPersonality;
        int evilRatio;
        int sfCount;
        public string[] sins;
        public string[] favors;
        public string causeOfDeath;
        public int deathAge;



        public human()
        {
            gender = humanDatabase.genderData[Random.Range(0, humanDatabase.genderData.Length)];
            name = gender == 'M' ? humanDatabase.maleNameData[Random.Range(0, humanDatabase.maleNameData.Length)] : humanDatabase.femaleNameData[Random.Range(0, humanDatabase.femaleNameData.Length)];
            surname = humanDatabase.surnameData[Random.Range(0, humanDatabase.surnameData.Length)];
            evilRatio = 0;
            sfCount = Random.Range(4, 9);


            humanPersonality = (personality)Random.Range(0, 4);
            switch (humanPersonality)
            {
                case personality.ExtremeSinner:
                    evilRatio = 100;



                    List<int> randomNumbers = new List<int>();
                    int number;
                    for (int i = 0; i < sfCount; i++)
                    {
                        do
                        {
                            number = Random.Range(0, humanDatabase.inexcusableSinsData.Length);
                        } while (randomNumbers.Contains(number));
                        randomNumbers.Add(number);
                    }
                    for (int i = 0; i < randomNumbers.Count; i++)
                    {
                        sins[i] = humanDatabase.inexcusableSinsData[randomNumbers[i]];
                    }








                    break;
                case personality.Sinner:
                    evilRatio = 50;
                    break;
                case personality.Neutral:
                    evilRatio = 0;
                    break;
                case personality.Saint:
                    evilRatio = -50;
                    break;
                case personality.ExtremeSaint:
                    evilRatio = -100;
                    break;
            }


            deathAge = Random.Range(19, 120);
            causeOfDeath = humanDatabase.causeOfDeathData[Random.Range(0, humanDatabase.causeOfDeathData.Length)];

        }
    }
}