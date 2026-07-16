class Product {
    int productId;
    String productName;
    String category;

    Product(int productId, String productName, String category) {
        this.productId = productId;
        this.productName = productName;
        this.category = category;
    }

    void display() {
        System.out.println("Product ID: " + productId);
        System.out.println("Product Name: " + productName);
        System.out.println("Category: " + category);
    }
}

public class EcommercePlatformSearchFunction{

    public static Product linearSearch(Product[] products, int key) {
        for (int i = 0; i < products.length; i++) {
            if (products[i].productId == key) {
                return products[i];
            }
        }
        return null;
    }

    public static Product binarySearch(Product[] products, int key) {
        int low = 0;
        int high = products.length - 1;

        while (low <= high) {
            int mid = (low + high) / 2;

            if (products[mid].productId == key) {
                return products[mid];
            } else if (products[mid].productId < key) {
                low = mid + 1;
            } else {
                high = mid - 1;
            }
        }
        return null;
    }

    public static void main(String[] args) {

        Product[] products = {
            new Product(101, "Laptop", "Electronics"),
            new Product(102, "Mobile", "Electronics"),
            new Product(103, "Shoes", "Fashion"),
            new Product(104, "Watch", "Accessories"),
            new Product(105, "Bag", "Fashion")
        };

        int searchId = 104;

        System.out.println("=== Linear Search ===");
        Product result1 = linearSearch(products, searchId);

        if (result1 != null) {
            result1.display();
        } else {
            System.out.println("Product Not Found");
        }

        System.out.println("\n=== Binary Search ===");
        Product result2 = binarySearch(products, searchId);

        if (result2 != null) {
            result2.display();
        } else {
            System.out.println("Product Not Found");
        }

        System.out.println("\nTime Complexity Analysis:");
        System.out.println("Linear Search -> Best: O(1), Average: O(n), Worst: O(n)");
        System.out.println("Binary Search -> Best: O(1), Average: O(log n), Worst: O(log n)");
    }
}
