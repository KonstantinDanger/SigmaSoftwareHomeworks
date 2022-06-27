using System.Text.RegularExpressions;

namespace Task_6_2
{
    public class TextHandler
    {
        private string _text;

        public TextHandler()
        {
            _text = null;
        }

        public TextHandler(string text)
        {
            _text = text;
        }

        public string FindLongestWords()
        {
            if (_text == null)
                throw new ArgumentNullException();

            string[] str = _text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            string[] longest = new string[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                MatchCollection sentences = Regex.Matches(str[i], @"[А-Яа-яіІ]+");
                string word = "";

                for (int j = 0; j < sentences.Count; j++)
                {
                    if (sentences[j].Length > word.Length)
                    {
                        word = sentences[j].ToString();
                    }
                }

                longest[i] = word;
            }

            return String.Join(", ", longest);
        }

        public string FindShortestWords()
        {
            if (_text == null)
                throw new ArgumentNullException();

            string[] str = _text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            string[] shortest = new string[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                MatchCollection sentences = Regex.Matches(str[i], @"[А-Яа-яіІ]+");
                string word = "                                    ";

                for (int j = 0; j < sentences.Count; j++)
                {
                    if (sentences[j].Length < word.Length)
                    {
                        word = sentences[j].ToString();
                    }
                }

                shortest[i] = word;
            }

            return String.Join(", ", shortest);
        }

        public void DivideBySentences()
        {
            string[] str = _text.Split(new char[] {'\n', ' '}, StringSplitOptions.RemoveEmptyEntries);
            string txt = String.Join(" ", str);

            char[] text = txt.ToCharArray();

            for (int i = 0; i < text.Length; i++)
            {
                if(text[i] == '.' && i != text.Length-1)
                {
                    text[i+1] = '\n';
                }
            }

            _text = new string(text);
        }
       
        public void GetTextFromFile(string path)
        {
            if(path == null)
                throw new ArgumentNullException("path null exception");

            using (StreamReader reader = new StreamReader(path))
            {
                _text = reader.ReadToEnd();
            }
        }
  
        public void PrintResultInFile(string path)
        {
            if (path == null)
                throw new ArgumentNullException("path null exception");

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.Write(_text);
            }
        }

        public override string ToString()
        {
            return string.Format($"Current text:\n\"{_text}\"\n\nLongest words of each sentence: {FindLongestWords()}.\nShortest words of each sentence: {FindShortestWords()}."); 
        }
    }
}
