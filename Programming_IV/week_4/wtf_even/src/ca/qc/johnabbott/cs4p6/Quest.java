package ca.qc.johnabbott.cs4p6;

public class Quest implements Comparable{

    private int energy;
    private int gold;


    public int getEnergy(){

        return energy;
    }

    public void setEnergy(int newEnergy){

        this.energy = newEnergy;
    }

    public int getGold(){

        return gold;
    }

    public void setGold(int newGold){

        this.gold = newGold;
    }

    @Override
    public int compareTo(Object o) {
        return 0;
    }

    @Override
    public String toString() {
        // in my to string should this be my get and setters (?)
        return String.format("(E: %d, G: %d) ", energy, gold);
    }
}
