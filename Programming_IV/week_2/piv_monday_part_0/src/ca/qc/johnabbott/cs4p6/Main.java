package ca.qc.johnabbott.cs4p6;

import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {


    }

    public static int cut(String inputFileName, String outputFileName, String format, char delimiter) throws IOException {
        Scanner scanner = new Scanner(new FileReader(inputFileName));
        PrintWriter writer = new PrintWriter(new FileWriter(outputFileName));

        scanner.useDelimiter(Character.toString(delimiter));
        List<String> fields = new ArrayList<>();

        int lines = 0;

        while(scanner.hasNext()){

            String token = scanner.next();

            if(token.contains("\n")){
                lines++;
                int pos = token.indexOf('\n');
                String first = token.substring(0, pos);
                String second = token.substring(pos + 1);

                fields.add(first);

                for(String number : format.split(",")) // ex: "1,2,3"
                {
                    int x = Integer.parseInt(number);
                    writer.println(fields.get(x));
                }
                writer.println();

                fields.clear();
                fields.add(second);


            }
            else
            {
                fields.add(token);
            }
        }

        scanner.close();
        writer.close();
        return lines;
    }
}
