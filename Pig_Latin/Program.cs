public class PigLatin
{
    public static void Main()
    {
        int fmt;
        string inputWord;
        string output = "";
        string input;
        bool validString = true;

        while (true)
        {
            Console.WriteLine("Put your sentence in.");

            do
            {
                input = Console.ReadLine();
                
                if (input == "") // Checks for empty string.
                {
                    validString = false;
                    Console.WriteLine("There is nothing to translate here. Enter something else.");
                    continue;
                }

                for (int i = 0; i < input.Length; i++) // Checks if there are letters in the input.
                {
                    if (Char.IsLetter(input, i))
                    {
                        validString = true;
                        break;
                    }
                    if (i == input.Length - 1)
                    {
                        Console.WriteLine("There is nothing to translate here. Enter something with letters.");
                        validString = false;
                    } 
                }
            } while (!validString); // We keep running this until the user gives us a correct input.
            




            for (int i = 0; i < input.Split().Length; i++) // Goes through the words in input and translates them.
            {
                if (input.Split()[i].Length == 0) // Inputs like "a " or multi-spaces cause there to be "" strings, which cause errors.
                    continue;

                inputWord = input.Split()[i];

                if (inputWord.Intersect("12345678990@#$%\\^&*").Any())
                {
                    output = (output + " " + inputWord);
                    continue;
                }

                if (inputWord == inputWord.ToUpper() && inputWord.Length != 1) // Records case of word
                    fmt = 1;
                else if (inputWord == inputWord.ToLower())
                    fmt = 2;
                else
                    fmt = 3;

                if (inputWord.Substring(0, 1).ToLower().Intersect("aeiou").Any()) // Translates word
                    inputWord = inputWord + "way";
                else if (inputWord.Length == 1)
                    inputWord = inputWord.Substring(i, 1) + "ay";
                else
                    for (int j = 1; j < inputWord.Length; j++)
                    {
                        if (inputWord.Substring(j, 1).ToLower().Intersect("aeiou").Any())
                        {
                            inputWord = inputWord.Substring(j, inputWord.Length - j) + inputWord.Substring(0, j) + "ay";
                            break;
                        }
                    }

                switch (fmt) // Takes translated word and puts it in correct casing.
                {
                    case 1:
                        inputWord = inputWord.ToUpper();
                        break;
                    case 2:
                        inputWord = inputWord.ToLower();
                        break;
                    case 3:
                        inputWord = inputWord.Substring(0, 1).ToUpper() + inputWord.Substring(1, inputWord.Length - 1).ToLower();
                        break;
                }

                for (int j = 0; j < inputWord.Length; j++) // Orders left parentheses.
                {
                    if (inputWord.Substring(j, 1).Intersect("(").Any())
                    {
                        inputWord = inputWord.Substring(j, 1) + inputWord.Substring(0, j) + inputWord.Substring(j + 1, inputWord.Length - j - 1);
                    }

                }
                int k = 2*(inputWord.Length - 1);
                int count;

                while (k != 0)
                {
                    count = k % inputWord.Length; // We use this to run the loop twice. The first time orders them in reverse. The second reverses that.
                    Console.WriteLine(k);
                    if (inputWord.Substring(count, 1).Intersect(".,!?;").Any()) // This places things in reverse, but "?!?!" and "..." reversed mean the same thing.
                    {
                        inputWord = inputWord.Substring(0, count) + inputWord.Substring(count + 1, inputWord.Length - count - 1) + inputWord.Substring(count, 1);
                    }
                    else if (inputWord.Substring(count, 1).Intersect(")").Any())
                    {
                        inputWord = inputWord.Substring(0, count) + inputWord.Substring(count + 1, inputWord.Length - count - 1) + inputWord.Substring(count, 1);
                    }
                    k--;
                }

                output = (output + " " + inputWord);

            }

            Console.WriteLine("Here is your string in Pig Latin:" + output);

            output = "";

            Console.WriteLine("Do you like to translate again? y/n");

            if (Console.ReadLine().ToLower() != "y")
                break;

        }
    }
}