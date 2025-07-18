using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Single item enqueue/dequeue
    // Expected Result: Dequeue returns enqueued item
    // Defect(s) Found: None (basic functionality worked)
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Multiple items with different priorities
    // Expected Result: Highest priority dequeued first
    // Defect(s) Found: Dequeued lowest priority first instead of highest
    public void TestPriorityQueue_HighestPriorityFirst()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 2);
        priorityQueue.Enqueue("High", 3);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Multiple items with same priority
    // Expected Result: Items dequeued in FIFO order
    // Defect(s) Found: Same-priority items not dequeued in insertion order
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Second", 1);
        priorityQueue.Enqueue("Third", 1);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Mixed priorities with same highest priority
    // Expected Result: FIFO order for same-priority items
    // Defect(s) Found: Highest priority items not dequeued in insertion order
    public void TestPriorityQueue_MixedPrioritiesSameHighest()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A_Med", 2);
        priorityQueue.Enqueue("B_High1", 3);
        priorityQueue.Enqueue("C_Low", 1);
        priorityQueue.Enqueue("D_High2", 3);

        Assert.AreEqual("B_High1", priorityQueue.Dequeue());
        Assert.AreEqual("D_High2", priorityQueue.Dequeue());
        Assert.AreEqual("A_Med", priorityQueue.Dequeue());
        Assert.AreEqual("C_Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: Throws InvalidOperationException
    // Defect(s) Found: No exception thrown for empty queue
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        var ex = Assert.ThrowsException<InvalidOperationException>(() =>
        {
            priorityQueue.Dequeue();
        });

        Assert.AreEqual("Queue is empty", ex.Message);
    }

    [TestMethod]
    // Scenario: Enqueue after dequeue
    // Expected Result: Maintains correct priority ordering
    // Defect(s) Found: State corruption after dequeue-enqueue sequence
    public void TestPriorityQueue_EnqueueAfterDequeue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 2);
        priorityQueue.Enqueue("Second", 3);
        Assert.AreEqual("Second", priorityQueue.Dequeue());

        priorityQueue.Enqueue("Third", 1);
        priorityQueue.Enqueue("Fourth", 3);

        Assert.AreEqual("Fourth", priorityQueue.Dequeue());
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Complex mixed priorities
    // Expected Result: Correct priority ordering with FIFO for same priorities
    // Defect(s) Found: Incorrect priority comparisons and ordering
    public void TestPriorityQueue_ComplexScenario()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 1);
        priorityQueue.Enqueue("C", 2);
        priorityQueue.Enqueue("D", 3);
        priorityQueue.Enqueue("E", 2);
        priorityQueue.Enqueue("F", 4);

        Assert.AreEqual("F", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("E", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
    }
}
