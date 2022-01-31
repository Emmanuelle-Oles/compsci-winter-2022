package ca.qc.johnabbott.cs4p6;

import java.io.FileReader;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Scanner;

public class Main {

    /**
     * Extract specified fields from the input data structured in columns by a delimiter.
     * @param inputFileName The file to read the data from, if blank then read from standard input.
     * @param outputFileName The file to write the data to, if blank then write to standard output.
     * @param format Determines the format of the output file. Comma delimited numbers and/or number
     *               range corresponding to the columns in the input data. Ex: "1,3,2" would output
     *               columns 1 and 3 and 2 in the output (comma delimited). You can specify ranges "1-3"
     *               or open-ended ranges "-5" or "2-". Columns can be repeated in the output.
     * @param delimiter The character delimiting the columns.
     * @return The number of lines read.
     * @throws IOException If there is a problem reading or writing the files.
     */

    public static void main(String[] args) {

        try{
            //todo
        }
        catch (IOException e)
        {
            e.printStackTrace();
        }

    }


    public static int cut(String inputFileName, String outputFileName, String format, char delimiter) throws
    IOException {
        Scanner scanner = new Scanner(new FileReader(inputFileName));
        PrinterWriter writer = new PrintWriter(new fileWriter(outputFileName));

        scanner.useDelimiter(delimiter);


        while(scanner.hasNext())
        {
            writer.println(scanner.next());
        }




    }
}
