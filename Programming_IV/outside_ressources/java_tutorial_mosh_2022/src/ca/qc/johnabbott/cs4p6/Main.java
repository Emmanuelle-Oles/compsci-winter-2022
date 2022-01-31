package ca.qc.johnabbott.cs4p6; // package statement, it belongs to ca.qc.johnabbott.cs4p6


import java.awt.*;
import java.text.NumberFormat;
import java.util.Arrays;
import java.util.Date;
import java.util.Scanner;

// Main Class Pascal
public class Main {

    // Main method should always be static
    public static void main(String[] args) {
        byte myAge = 35;
        // by default java see this as int
        long viewCount =  3_123_456_798L;
        // by default java sees this as a double
        float price = 10.99F;
        char letter = 'A';
        boolean isEligible = true;
        Date now = new Date();
        now.getTime();
        //sout keyboard shortcut
        System.out.println(now);
        //out is a field
        System.out.println(myAge);

        //primitive types
        byte x = 1;
        byte y = x;
        x = 2;
        System.out.println(y);
        System.out.println(x);

        //reference types
        //these two are referring to the same space in memory
        Point point1 = new Point(1, 1);
        Point point2 = point1;

        System.out.println(point1);
        System.out.println(point2);

        //arrays old way of init
        int[] numbers = new int[5];
        numbers[0] = 1;
        numbers[0] = 1;
        numbers[0] = 1;

        System.out.println(Arrays.toString(numbers));

        int[] numbers1 = { 1, 2, 3, 4};
        System.out.println(numbers1.length);
        System.out.println(Arrays.toString(numbers1));

        int[][] matrix = new int[2][3];
        matrix[0][0] = 1;

        System.out.println(Arrays.deepToString(matrix));

        int[][] matrix1 = {{1,2,3,4}, {2,3,4,5}};
        System.out.println(Arrays.deepToString(matrix1));

        // implicit casting only happens when theres no potential data loss
        // byte > short > int > long
        short a = 1;
        int b = a + 2;
        System.out.println(b);

        // wrapper classes
        // Integer.parseInt();

        String c = "2";
        int e = Integer.parseInt(c) + 3;
        System.out.println(e);

        // math class
        int result = Math.round(1.1F);
        System.out.println(result);
        int result1 = (int)Math.ceil(1.1F);
        System.out.println(result1);
        int result2 = (int)Math.floor(1.1F);
        System.out.println(result2);

        int result3 = (int) (Math.random() * 100);
        System.out.println(result3);

        //formatting
        //1,213,213$
        //10%

        //this is an abstract classes
        NumberFormat currency = NumberFormat.getCurrencyInstance();
        String result4 = currency.format(12345.138);
        System.out.println(result4);

        String result5 = NumberFormat.getPercentInstance().format(0.1);

        // reading input from user

        Scanner scanner = new Scanner(System.in);
        System.out.print("Age: ");
        byte age = scanner.nextByte();
        System.out.println("you are " + age);

        // to read from a string is next and
        Scanner scanner1 = new Scanner(System.in);
        System.out.print("Name: ");
        String name = scanner.nextLine().trim();
        System.out.println("you are " + age);


        // creating mortgage calculator
        final byte YEAR = 12;
        final byte PERCENTAGE = 100;
        Scanner scanner2 = new Scanner(System.in);

        System.out.print("Principal: ");
        float principal = scanner.nextFloat();

        System.out.print("Annual Interest Rate : ");
        float annualInterest = scanner.nextFloat();
        float monthlyRate = annualInterest / YEAR / PERCENTAGE;


        System.out.print("Period (Years): ");
        byte period = scanner.nextByte();
        int monthsPayment = period * YEAR;

        double mortgage = principal
                    * ( monthlyRate * Math.pow(1 + monthlyRate, monthsPayment ))
                    / ( Math.pow(1 + monthlyRate, monthsPayment) - 1 );

        System.out.println("Your mortgage payment is going to be : " + mortgage);

        // control the flow

        //comparison operators

        int p = 1;
        int q = 1;

        System.out.println(p == q);


        // logical operators
        boolean hasHighIncome = false;
        boolean hasGoodCredit = true;
        boolean hasCriminalRecord = false;
        boolean isEligible1 = ( hasHighIncome || hasGoodCredit ) && !hasCriminalRecord;

        //

        int temperature = 32;
        int max = 30;
        if(temperature > max ){
            System.out.println("its a hot day");
            System.out.println("drink water");
        }
        else if ( temperature > 20 && temperature <= 30)
            System.out.println("Beautiful day!");
        else
            System.out.println("Cold day!");

        int income = 120_000;
        boolean hasHighIncome1 = (income > 100_000);

        String className = income > 100_000 ? "First" : "Economy";



        Scanner scanner3 = new Scanner(System.in);
        System.out.print("Number: ");

        int number = scanner.nextInt();

        if(number % 5 == 0 && number % 3 == 0)
            System.out.println("FizzBuzz");




    }


}
