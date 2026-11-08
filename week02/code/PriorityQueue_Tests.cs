using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue A (1), B (5), C (3) and dequeue until empty.
    // Expected Result: B, C, A (highest priority first, and each item is removed after it is returned)
    // Defect(s) Found: Dequeue returned the value but never removed the item from the list, so B was
    // returned again on the second call instead of C.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("[]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Enqueue A (1), B (2), C (9) so the highest priority item is at the back of the queue.
    // Expected Result: C
    // Defect(s) Found: The search loop used "index < _queue.Count - 1", so it never checked the last
    // item in the queue. C was skipped and B was returned.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 9);

        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue A (5), B (5), C (1), D (5) so several items share the highest priority.
    // Expected Result: A, B, D, C (ties are removed in FIFO order, closest to the front first)
    // Defect(s) Found: The comparison used ">=", so on a tie it moved to the later item instead of
    // keeping the one closest to the front. B was returned before A.
    public void TestPriorityQueue_Ties()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 1);
        priorityQueue.Enqueue("D", 5);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue A (1), B (2), C (3) and check the order of the queue.
    // Expected Result: Items are added to the back: [A (Pri:1), B (Pri:2), C (Pri:3)]
    // Defect(s) Found: None. Enqueue already added items to the back of the queue.
    public void TestPriorityQueue_EnqueueToBack()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 3);

        Assert.AreEqual("[A (Pri:1), B (Pri:2), C (Pri:3)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: InvalidOperationException with the message "The queue is empty."
    // Defect(s) Found: None. The empty check already threw the correct exception and message.
    public void TestPriorityQueue_Empty()
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
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                              e.GetType(), e.Message)
            );
        }
    }
}
