using System.Linq.Expressions;
using System.Text;

namespace MyvarUI.Mudle
{
    public class MudleParser
    {
        public static MudleObject Parse(string s)
        {
            var re = new MudleObject();

            var inComment = false;
            int state = 0;
            var sb = new StringBuilder();
            var headerBuf = "";
            int depth = 1;
            string nameBuf = "";
            string implmentsBuf = "";

            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (inComment)
                {
                    if (c == '\n') inComment = false;
                }
                else
                {
                    if (c == '/' && s.Length > i + 1 && s[i + 1] == '/')
                    {
                        inComment = true;
                        continue;
                    }

                    switch (state)
                    {
                        case 0:
                            if (c == '{')
                            {
                                headerBuf = sb.ToString().Trim();
                                var segs = headerBuf.Split(':');
                                re.Name = segs[0].Trim();
                                re.Implments = segs[1].Trim();
                                sb.Clear();
                                state = 1;
                            }
                            else
                            {
                                sb.Append(c);
                            }
                            break;
                        case 1:
                            if (c == '}')
                            {
                                sb.Clear();
                                state = 0;
                            }

                            if (c == ':')
                            {
                                nameBuf = sb.ToString().Trim();
                                sb.Clear();
                                state = 2;
                            }
                            else
                            {
                                sb.Append(c);
                            }
                            break;
                        case 2:
                            if (c == ';')
                            {
                                //we have a propertie
                                re.Properties.Add(nameBuf,
                                    new MudlePropertie() {Name = nameBuf, Value = sb.ToString().Trim()});
                                sb.Clear();
                                state = 1;
                            }
                            else if (c == '{')
                            {
                                //we have a nother mudleobject
                                state = 3;
                                implmentsBuf = sb.ToString().Trim();
                                sb.Clear();
                                continue;
                            }
                            else
                            {
                                sb.Append(c);
                            }
                            break;
                        case 3:

                            if (c == '{') depth++;
                            if (c == '}') depth--;

                            if (depth == 0)
                            {
                                depth = 1;
                                state = 1;

                                re.Children.Add(nameBuf,
                                    Parse(nameBuf + ":" + implmentsBuf + "{" + sb.ToString() + "}"));

                                sb.Clear();

                            }
                            else
                            {
                                sb.Append(c);
                            }


                            break;
                    }
                }
            }

            return re;
        }
    }
}