public class FinancialForecasting {

    public static double futureValue(double amount, double growthRate, int years) {

        if (years == 0) {
            return amount;
        }

        return futureValue(amount, growthRate, years - 1) * (1 + growthRate);
    }

    public static void main(String[] args) {

        double presentValue = 10000;

        double growthRate = 0.10;

        int years = 5;

        double futureValue = futureValue(presentValue, growthRate, years);

        System.out.println("===== Financial Forecasting Using Recursion =====");
        System.out.println("Present Value : ₹" + presentValue);
        System.out.println("Growth Rate   : " + (growthRate * 100) + "%");
        System.out.println("Years         : " + years);
        System.out.println("Future Value  : ₹" + futureValue);

        System.out.println("\n===== Complexity Analysis =====");
        System.out.println("Time Complexity  : O(n)");
        System.out.println("Space Complexity : O(n)");
        System.out.println("Reason: One recursive call is made for each year.");

        double optimizedValue = presentValue * Math.pow(1 + growthRate, years);

        System.out.println("\n===== Optimized Approach Using Math.pow() =====");
        System.out.println("Future Value  : ₹" + optimizedValue);
        System.out.println("Time Complexity  : O(log n) (efficient power calculation)");
        System.out.println("Space Complexity : O(1)");
    }
}