﻿/*
The MIT License(MIT)
Copyright(c) 2015 Freddy Juhel
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using System;
namespace SearchAllCombinaisons
{
  public class Program
  {
    private static readonly char[] PossibleCharacters =  {'0','1','2','3','4','5','6','7','8','9',
      'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
      'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
      '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '[', ']', '{', '}',
      ';', ':', ',', '.', '<', '>', '/', '?' };
    private static string _findPassword;
    private static int _combinaisons;

    public static void Main()
    {
      int count;
      Console.WriteLine("Enter your Password");
      _findPassword = Console.ReadLine();
      DateTime today = DateTime.Now;
      Console.WriteLine("START:\t{0}", today.ToString("yyyy-MM-dd_HH:mm:ss"));
      for (count = 0; count <= 15; count++)
      {
        Recurse(count, 0, "");
      }
    }

    private static void Recurse(int length, int position, string baseString)
    {
      for (int count = 0; count < PossibleCharacters.Length; count++)
      {
        _combinaisons++;
        if (position < length - 1)
        {
          Recurse(length, position + 1, baseString + PossibleCharacters[count]);
        }

        if (baseString + PossibleCharacters[count] == _findPassword)
        {
          DateTime today = DateTime.Now;
          Console.WriteLine("END:\t{0}\nNumber of combinaisons:\t{1}", today.ToString("yyyy-MM-dd_HH:mm:ss"), _combinaisons);
          Console.WriteLine("Press a key to exit:");
          Console.ReadKey();
          Environment.Exit(0);
        }

        Console.WriteLine(_combinaisons);
      }
    }
  }
}