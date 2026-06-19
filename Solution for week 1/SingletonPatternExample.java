class Logger {

    private static Logger instance = new Logger();

    private Logger() {
        System.out.println("Logger Instance Created");
    }

    public static Logger getInstance() {
        return instance;
    }

    public void log(String message) {
        System.out.println("LOG: " + message);
    }
}

public class SingletonPatternExample {               // test class

    public static void main(String[] args) {

        Logger logger1 = Logger.getInstance();
        Logger logger2 = Logger.getInstance();

        logger1.log("Application Started");
        logger2.log("User Logged In");

        System.out.println("\nChecking Instances...");

        if (logger1 == logger2) {
            System.out.println("Only one Logger instance exists.");
        } else {
            System.out.println("Multiple Logger instances exist.");
        }
    }
}