package ca.qc.johnabbott.cs4p6;

public class IPAddress {

    // class members

    // fields
    private int[] octet;

    //constructor
    public IPAddress() {
        octet = new int[4];
    }

    public IPAddress(String address){
        this(); // did we call the previous class
        String[] temp = address.split("\\.");


        for(int i = 0; i < 4; i++){
            int x = Integer.parseInt(temp[i]);
            if(x < 0 || x > 255)
            {
                throw new IllegalArgumentException("Bad octect " + x);
            }

            octet[i] = x;
        }

    }

    public String format()
    {
        return null;
    }

    public boolean inNetwork(IPAddress ip1, int i){
        return false;
    }

    public int compareTo(IPAddress ip2)
    {
        return 0;
    }


}
