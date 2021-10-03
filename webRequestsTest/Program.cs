using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace webRequestsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MEW();
        }
        private static void MEW()
        {
            List<string> wordsPost = new List<string>();
            List<string> wordsGet1 = new List<string>();
            List<string> wordsGet2 = new List<string>();
            List<string> merge = new List<string>();
            string[] wordsGetFinal = new string[4];
            
            for (int i = 0; i < 4; i++)
            {
                string temp;
                do
                {
                    temp = Console.ReadLine();
                } while (wordsPost.Contains(temp));
                wordsPost.Add(temp);
            }

            WebRequest request = WebRequest.Create("http://127.0.0.1:7777/");
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "MEW";
            
            request.Headers.Add("X-Cat-Variable", wordsPost[0]);
            request.Headers.Add("X-Cat-Variable", wordsPost[1]);
            WebResponse response = request.GetResponse();
            wordsGet1.AddRange(response.Headers.Get("X-Cat-Value").Split(", "));
            response.Close();
            if (wordsGet1[0] == wordsGet1[1])
            {
                wordsGetFinal[0] = wordsGet1[0];
                wordsGetFinal[1] = wordsGet1[1];
                WebRequest request2 = WebRequest.Create("http://127.0.0.1:7777/");
                request2.Credentials = CredentialCache.DefaultCredentials;
                request2.Method = "MEW";
                request2.Headers.Add("X-Cat-Variable", wordsPost[2]);
                request2.Headers.Add("X-Cat-Variable", wordsPost[3]);
                
                WebResponse response2 = request2.GetResponse();
                wordsGet2.AddRange(response2.Headers.Get("X-Cat-Value").Split(", "));
                response2.Close();
                if (wordsGet2[0] == wordsGet2[1])
                {
                    wordsGetFinal[2] = wordsGet2[1];
                    wordsGetFinal[3] = wordsGet2[0];
                }
                else
                {
                    WebRequest request3 = WebRequest.Create("http://127.0.0.1:7777/");
                    request3.Credentials = CredentialCache.DefaultCredentials;
                    request3.Method = "MEW";
                    request3.Headers.Add("X-Cat-Variable", wordsPost[3]);
                    
                    WebResponse response3 = request3.GetResponse();
                    string finaltemp = response3.Headers.Get("X-Cat-Value");
                    response3.Close();
                    wordsGetFinal[3] = finaltemp;
                    wordsGetFinal[2] = wordsGet2[0] == finaltemp ? wordsGet2[1] : wordsGet2[0];
                }
            }
            else
            {
                WebRequest request2 = WebRequest.Create("http://127.0.0.1:7777/");
                request2.Credentials = CredentialCache.DefaultCredentials;
                request2.Method = "MEW";
                request2.Headers.Add("X-Cat-Variable", wordsPost[0]);
                request2.Headers.Add("X-Cat-Variable", wordsPost[2]);
                
                WebResponse response2 = request2.GetResponse();
                wordsGet2.AddRange(response2.Headers.Get("X-Cat-Value").Split(", "));
                response2.Close();

                if (wordsGet2[0] == wordsGet2[1])
                {
                    wordsGetFinal[0] = wordsGet2[0];
                    wordsGetFinal[2] = wordsGet2[1];
                    wordsGetFinal[1] = wordsGet2[1] == wordsGet1[1] ? wordsGet1[0] : wordsGet1[1];
                    
                    WebRequest request3 = WebRequest.Create("http://127.0.0.1:7777/");
                    request3.Credentials = CredentialCache.DefaultCredentials;
                    request3.Method = "MEW";
                    request3.Headers.Add("X-Cat-Variable", wordsPost[3]);
                    
                    WebResponse response3 = request3.GetResponse();
                    wordsGetFinal[3] = response3.Headers.Get("X-Cat-Value");
                    response3.Close();
                }
                else
                {
                    if (wordsGet1.OrderBy(x => x).SequenceEqual(wordsGet2.OrderBy(x => x)))
                    {
                        List<string> temp3 = new List<string>();
                        WebRequest request3 = WebRequest.Create("http://127.0.0.1:7777/");
                        request3.Credentials = CredentialCache.DefaultCredentials;
                        request3.Method = "MEW";
                        request3.Headers.Add("X-Cat-Variable", wordsPost[0]);
                        request3.Headers.Add("X-Cat-Variable", wordsPost[3]);
                
                        WebResponse response3 = request3.GetResponse();
                        temp3.AddRange(response3.Headers.Get("X-Cat-Value").Split(", "));
                        response3.Close();

                        if (temp3[0] == temp3[1])
                        {
                            wordsGetFinal[0] = temp3[0];
                            wordsGetFinal[3] = temp3[0];
                            wordsGetFinal[1] = temp3[0] == wordsGet2[0] ? wordsGet2[1] : wordsGet2[0];
                            wordsGetFinal[2] = temp3[0] == wordsGet1[0] ? wordsGet1[1] : wordsGet1[0];
                        }
                        else
                        {
                            if (wordsGet1[0] == temp3[0])
                            {
                                wordsGetFinal[0] = wordsGet1[0] == temp3[0] ? wordsGet1[0] : wordsGet1[1];
                            }
                            else
                            {
                                wordsGetFinal[0] = wordsGet1[1] == temp3[0] ? wordsGet1[1] : wordsGet1[0];
                            }

                            if ((wordsGet1[0] == temp3[0] || wordsGet1[0] == temp3[1]))
                            {
                                wordsGetFinal[1] = wordsGet1[0] == temp3[0] ? wordsGet1[1] : wordsGet1[0];
                            }
                            else
                            {
                                wordsGetFinal[1] = wordsGet1[0] == temp3[0] ? wordsGet1[0] : wordsGet1[1];
                            }

                            if (wordsGet2[1] == temp3[0] || wordsGet2[1] == temp3[1])
                            {
                                wordsGetFinal[2] = wordsGet2[1] == temp3[0] || wordsGet2[1] == temp3[1] ? wordsGet2[0] : wordsGet2[1];
                            }
                            else
                            {
                                wordsGetFinal[2] = wordsGet2[1] == temp3[0] ? wordsGet2[0] : wordsGet2[1];
                            }
                            
                            if (wordsGet1[0] == temp3[0])
                            {
                                wordsGetFinal[3] = wordsGet1[0] == temp3[0] ? temp3[1] : temp3[0];
                            }
                            else
                            {
                                wordsGetFinal[3] = wordsGet1[1] == temp3[0] ? temp3[1] : temp3[0];
                            }
                            
                        }
                    }
                    else if (wordsGet2[0] == wordsGet1[0] || wordsGet2[0] == wordsGet1[1])
                    {
                        wordsGetFinal[0] = wordsGet2[0];
                        wordsGetFinal[1] = wordsGet1[1] == wordsGet2[0] ? wordsGet1[0] : wordsGet1[1];
                        wordsGetFinal[2] = wordsGet2[1];
                        
                        WebRequest request3 = WebRequest.Create("http://127.0.0.1:7777/");
                        request3.Credentials = CredentialCache.DefaultCredentials;
                        request3.Method = "MEW";
                        request3.Headers.Add("X-Cat-Variable", wordsPost[3]);
                    
                        WebResponse response3 = request3.GetResponse();
                        wordsGetFinal[3] = response3.Headers.Get("X-Cat-Value");
                        response3.Close();
                    }
                    else if (wordsGet2[1] == wordsGet1[0] || wordsGet2[1] == wordsGet1[1])
                    {
                        wordsGetFinal[0] = wordsGet2[1];
                        wordsGetFinal[1] = wordsGet1[1] == wordsGet2[1] ? wordsGet1[0] : wordsGet1[1];
                        wordsGetFinal[2] = wordsGet2[0];
                        
                        WebRequest request3 = WebRequest.Create("http://127.0.0.1:7777/");
                        request3.Credentials = CredentialCache.DefaultCredentials;
                        request3.Method = "MEW";
                        request3.Headers.Add("X-Cat-Variable", wordsPost[3]);
                    
                        WebResponse response3 = request3.GetResponse();
                        wordsGetFinal[3] = response3.Headers.Get("X-Cat-Value");
                        response3.Close();
                    }
                    
                }
            }
            foreach (var item in wordsGetFinal)
            {
                Console.WriteLine(item);
            }
        }
    }
}