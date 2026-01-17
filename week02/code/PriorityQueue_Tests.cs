using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Dequeue from a queue with items of different priorities
    // Expected Result: Should return the item with the highest priority (5)
    // Defect(s) Found: Without Fix 2 (using >= instead of >), it would return the last item with priority 5 instead of first
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("AlsoHigh", 5);
        
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Dequeue all items and verify they come out in priority order
    // Expected Result: Items should be dequeued in order: High(5), Medium(3), Low(1)
    // Defect(s) Found: Without Fix 3 (RemoveAt), items would not be removed and same item returned repeatedly
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("High", 5);
        
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: Should throw InvalidOperationException
    // Defect(s) Found: None - error handling works correctly
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Multiple items with same priority (tie-breaking test)
    // Expected Result: When priorities are equal, should return first one added
    // Defect(s) Found: Without Fix 2 (> instead of >=), would return last item in tie
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 3);
        priorityQueue.Enqueue("Second", 3);
        priorityQueue.Enqueue("Third", 3);
        
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add items after dequeuing some
    // Expected Result: Should correctly find highest priority among remaining items
    // Defect(s) Found: Without Fix 1 (< instead of <=), would skip last item in queue
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("High", 5);
        
        priorityQueue.Dequeue(); // Remove "High"
        priorityQueue.Enqueue("VeryHigh", 7);
        
        Assert.AreEqual("VeryHigh", priorityQueue.Dequeue());
    }
}