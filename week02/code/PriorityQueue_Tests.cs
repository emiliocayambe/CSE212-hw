using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities (Low, High, Medium) and dequeue them.
    // Expected Result: Items should be dequeued in order of highest priority first (High, Medium, Low).
    // Defect(s) Found: The original code failed because the loop missed the last element, used >= instead of > for tie-breaking, and forgot to remove items from the queue after dequeuing.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("LowPriority", 1);
        priorityQueue.Enqueue("HighPriority", 10);
        priorityQueue.Enqueue("MediumPriority", 5);

        Assert.AreEqual("HighPriority", priorityQueue.Dequeue());
        Assert.AreEqual("MediumPriority", priorityQueue.Dequeue());
        Assert.AreEqual("LowPriority", priorityQueue.Dequeue());
    }

  [TestMethod]
    // Scenario: Enqueue items with duplicate highest priorities and test dequeue from an empty queue.
    // Expected Result: Ties should follow the FIFO rule (the first added comes out first), and an empty queue should throw an InvalidOperationException with the message "The queue is empty."
    // Defect(s) Found: The original comparison operator violated FIFO order during priority ties, and attempting to dequeue an empty queue lacked proper removal handling and exception verification.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        
        // Testing FIFO behavior with duplicate high priorities
        priorityQueue.Enqueue("FirstHigh", 10);
        priorityQueue.Enqueue("SecondHigh", 10);
        priorityQueue.Enqueue("Low", 1);

        Assert.AreEqual("FirstHigh", priorityQueue.Dequeue());
        Assert.AreEqual("SecondHigh", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());

        // Testing empty queue exception handling
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("An exception should have been thrown for an empty queue.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }

}