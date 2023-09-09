using System;

public class Program
{
    public static void Main()
    {
        string choose = " ",
        sentence = " ",
        encryptedMessage = " ";
        Console.WriteLine("1.Sentence ");
        Console.WriteLine("2.Encrypted message");
        choose = Console.ReadLine();
        switch (choose)
        {
            case "1" :
                Console.WriteLine("Enter a sentence: ");
                sentence = Console.ReadLine();

               encryptedMessage = EncryptMessage(sentence);

                Console.WriteLine("Encrypted message: " + encryptedMessage);
                break;
            case "2" :
                Console.WriteLine("Enter an encrypted message: ");
                encryptedMessage = Console.ReadLine();

                string decryptedMessage = DecryptMessage(encryptedMessage);

                Console.WriteLine("Decrypted message: " + decryptedMessage);
                break;
            default :
                Console.WriteLine("you have defaulted!");
                break;
        }
    }

    public static string EncryptMessage(string sentence)
    {
        string encryptedMessage = "";

        foreach (char letter in sentence)
        {
            if (Char.IsLetter(letter))
            {
                int position = Char.ToLower(letter) - 'a' + 1;
                encryptedMessage += position.ToString() + " ";
            }
            else
            {
                encryptedMessage += letter;
            }
        }

        return encryptedMessage.Trim();
    }

    public static string DecryptMessage(string encryptedMessage)
    {
        string decryptedMessage = "";

        string[] positions = encryptedMessage.Split(' ');

        foreach (string position in positions)
        {
            if (string.IsNullOrWhiteSpace(position))
            {
                decryptedMessage += " ";
            }
            else
            {
                int numericPosition;
                if (int.TryParse(position, out numericPosition))
                {
                    char letter = (char)(numericPosition - 1 + 'a');
                    decryptedMessage += letter;
                }
                else
                {
                    decryptedMessage += position;
                }
            }
        }

        return decryptedMessage;
    }
}