package ca.qc.johnabbott.cs4p6;

import java.io.*;
import java.lang.reflect.Executable;
import java.util.Locale;
import java.util.Scanner;

public class Main {


    public static void main(String[] args) {
	// write your code here
    String testReadFile = "./data/sample0.txt";
    String testWriteFile = "./data/goldPayroll.txt";

        try
        {
            solve(testReadFile, testWriteFile);
        }
        catch(Exception e)
        {
            System.out.println("Something went wrong");
        }
    }

    public static void solve(String inputFileName, String outputFileName) throws Exception {

        final String QUEST_COMMAND = "add";
        final String ENERGY_COMMAND = "query";

        int i = 0;
        Scanner scanner = new Scanner(new FileReader(inputFileName));
        PrintWriter writer = new PrintWriter(new FileWriter(outputFileName));

        if(!scanner.hasNextInt())
        {
            //Ensure the first line of the file is a number
            throw new Exception();

        }
        while (scanner.hasNextLine())
        {
            // once you have validated that this is what you need to do pls put into another function called validation input

            System.out.println(scanner.nextLine());

            String currentLine = scanner.nextLine();

            String[] currentLineArray =  currentLine.split(" ");

            for(int j = 0; j < currentLineArray.length; j++ )
            {
                if(!currentLineArray[1].toLowerCase().contains(QUEST_COMMAND) || currentLineArray[1].toLowerCase().contains(ENERGY_COMMAND) )
                {
                    throw new Exception();
                }
            }

            // check if it is add or query -> hasNext("[]");
            // input validation for int -> hasnextInt()
            // do i need to also validate the length after add?


        }

        scanner.close();
        writer.close();


    }
}
