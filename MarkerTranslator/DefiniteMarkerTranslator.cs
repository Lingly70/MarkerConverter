using System;

class MarkerTranslator 
{
    static string MarkerTranslate(string phraseToTranslate, bool translateToHolySpeech) 
    {
        string result = "";
       
        if (translateToHolySpeech) 
        {
            for (int i = 0; i < phraseToTranslate.Length; i++) 
            {
                string letter = (phraseToTranslate[i].ToString()).ToUpper();
                if (letter==" ") 
                {
                    result += " ";
                } else 
                {
                result += ":Marker" + letter +":";
                }
            }
        } else 
        {
            for (int i = 0; i < phraseToTranslate.Length; i++) {
                if (phraseToTranslate[i] == ':' && phraseToTranslate[i+1] == 'M') 
                {
                    int LetterIndex = i + 6;
                    string letter = ((phraseToTranslate[LetterIndex]).ToString()).ToLower();
                    result += letter;
                }
                if (phraseToTranslate[i]==' ') 
                {
                    result += " ";
                }
            }
        }
        
        return result;
    }

    static void Main() 
    {
        bool UserWishesToStayInTheTranslator = true;
        bool UserWishesToStayInTheTranslatorWithSameTranslationOptions = false;
        bool UserHasPassedFirstLoop = false;

        string UserChoice = "";

        do {
            Console.WriteLine();
            Console.WriteLine("Welcome to the MTM2: Marker Translator Module, version 2.0.");
            Console.WriteLine();
            while (UserChoice!="1" && UserChoice!="2")  
            {
                Console.WriteLine("Please select your option. If you wish to translate from english to marker scriptures, then press 1. If the contrary, press 2.");
                UserChoice = Console.ReadLine();
                UserHasPassedFirstLoop = UserChoice == "1" || UserChoice == "2" ? true : false;
                
                if (!UserHasPassedFirstLoop) 
                {
                    Console.WriteLine("INVALID OPTION. Please try again.");
                }
            }
            bool userTranslatesToMarker = UserChoice == "1" || UserChoice == "2";
            do 
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the text you wish to convert.");
                Console.WriteLine("INFO: 0 to switch translation mode, 1 to quit the program.");
                string TextToBeConverted = Console.ReadLine();
                switch (TextToBeConverted) {
                    case "0":
                        userTranslatesToMarker = !userTranslatesToMarker;
                        break;
                    default:
                        Console.WriteLine("The text converted is as follows: ");
                        Console.WriteLine(MarkerTranslate(TextToBeConverted,userTranslatesToMarker));
                        break;
                }
            } while (UserWishesToStayInTheTranslatorWithSameTranslationOptions);
        } while (UserWishesToStayInTheTranslator);
    }
}