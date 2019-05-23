using System;
using System.IO;
using System.Collections;

namespace Program {

    namespace Ops {
        public class Operations {
            public static void multiply() {
                Console.WriteLine("This program asks for three numbers from the user and multiplies them.\n");
                Console.WriteLine("Enter the first number: ");
                try{
                    double numberOne = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("\nEnter the second number: ");
                    double numberTwo = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("\nEnter the third number: ");
                    double numberThree = Convert.ToDouble(Console.ReadLine());
                    double outputNum = numberOne * numberTwo * numberThree;
                    Console.WriteLine(numberOne + " * " + numberTwo + " * " + numberThree + " = " + outputNum);
                }
                catch (Exception ex) {
                    Console.WriteLine("A "+ ex + " exception occurred.\n" + "Please use number values only.");
                }
            }
        }
    }
    /**
    *
    * To Be Completed
    * At A Later Date
    *
    **/
    namespace Sorts {
        public class mergeSort {
            public static void mergeSortingFromFile(string fileName) {
                ArrayList fileArr = new ArrayList();
                try{
                    using(StreamReader sr = new StreamReader(fileName)) {
                        string line;
                        while((line = sr.ReadLine()) != null) {
                            int lineValue = Convert.ToInt32(line);
                            fileArr.Add(lineValue);
                        }
                    }
                }
                catch(FileNotFoundException ex) {
                    Console.WriteLine(ex);
                }
            }
        }
        public class insertionSort {
            public static ArrayList insertionSorting(){
                ArrayList numbersArray = new ArrayList();
                double arrCurrVal;
                Console.WriteLine("How many values would you like to enter: ");
                int numNumbs = Convert.ToInt32(Console.ReadLine());
                for(int i=0; i<=numNumbs; i++){
                    bool isAdded = false;
                    int counter = 0;
                    Console.WriteLine("Enter value: ");
                    double currValue = Convert.ToDouble(Console.ReadLine());
                    if(numbersArray.Count == 0){
                        numbersArray.Add(currValue);
                    }
                    else{
                        while(counter < numbersArray.Count & !(isAdded)){
                            arrCurrVal = Convert.ToDouble(numbersArray[counter]);
                            if(currValue < arrCurrVal){
                                numbersArray.Insert(counter, currValue);
                                isAdded = true;
                            }
                            counter++;
                        }
                        if(!(isAdded)){
                            numbersArray.Add(currValue);
                        }
                    }
                }
                return numbersArray;
            }
        }
    }
    namespace Strings {
        public class longestWord {
            public static string findLongestWord(string fileName){
                string currentLongestWord = "";
                try{
                    using(StreamReader sr = new StreamReader(fileName)){
                        string line;
                        string word;
                        while((line = sr.ReadLine()) != null){
                            string[] words = line.Split(" ");
                            for(int i=0; i<words.Length; i++){
                                word = words[i];
                                if(word.Length > currentLongestWord.Length){
                                    currentLongestWord = word;
                                }
                            }
                        }
                    }
                }
                catch(FileNotFoundException ex){
                    Console.WriteLine(ex);
                }
                return currentLongestWord;
            }
        }
    }
    public class MainProgram {
        public static void Main(String[] args) {
            bool runProgram = true;
            while(runProgram == true){
                Console.WriteLine("What function would you like to run:");
                Console.WriteLine("(1) Multiply Three Numbers");
                Console.WriteLine("(2) Find the Longest String in a file");
                Console.WriteLine("(3) Sort a file with one value on each line using merge sort");
                Console.WriteLine("(4) Insertion Sort");
                Console.WriteLine("(9) Exit Program");
                int funcToRun = Convert.ToInt32(Console.ReadLine());
                if(funcToRun == 1){
                    Ops.Operations.multiply();
                }
                else if(funcToRun == 2){
                    Console.WriteLine("Enter the name of the text file that you wish to use: ");
                    string fileName = Console.ReadLine();
                    string longWord = Strings.longestWord.findLongestWord(fileName);
                    Console.WriteLine("The longest word in the given file is: " + longWord + "\n");
                }
                else if(funcToRun == 3){
                    Console.WriteLine("Enter the name of the text file that you wish to use: ");
                    string fileName = Console.ReadLine();
                    Sorts.mergeSort.mergeSortingFromFile(fileName);
                }
                else if(funcToRun == 4){
                    ArrayList sortedArray = new ArrayList();
                    sortedArray = Sorts.insertionSort.insertionSorting();
                    Console.WriteLine();
                    Console.Write("[");
                    for(int i=0; i<sortedArray.Count; i++){
                        Console.Write(sortedArray[i] + ",");
                    }
                    Console.Write("]\n");
                }
                else if(funcToRun == 9){
                    runProgram = false;
                    Console.WriteLine("Exiting...");
                    // Environment.Exit(0);
                }
                else{
                    Console.WriteLine("Pick a valid option.");
                }
            }
        }
    }
}