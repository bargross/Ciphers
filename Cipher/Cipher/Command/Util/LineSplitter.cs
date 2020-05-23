using System.Text;

namespace Cipher.Command.Util
{
    public static class Splitter
    {
        private static StringBuilder _commandBuilder = new StringBuilder();


        private static string GetCommand(string line)
        {
            foreach (char character in line)
            {
                if (character == ' ') break;

                _commandBuilder.Append(character);
            }

            var command = _commandBuilder.ToString();

            _commandBuilder.Clear();

            return command;
        }

        public static (string, string) GetCommandAndWords(string line)
        {
            var command = GetCommand(line);
            var words = line.Split(line[command.Length], line.Length)[1];

            return (command, words);
        }
    }
}
