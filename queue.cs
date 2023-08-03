using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace assessEx1TaskCfinal
{
    class IntQueue
    {
       // private Customer[] customer;
        // private readonly int maxsize = 20;
        private Customer[] store; // store customers
        private int head = 0;  // begining of the customer queue
        private int tail = 0;   //end of the customer queue
        private int numItems;   //num of customers in queue
        private int count = 0;  //count num of num or items; allows for display of num
        private int maxsize;    //max customer the queue can hold



        public IntQueue(int size)
        {

            store = new Customer[size];    //an array storing the queue of customers
           // customer = new Customer[size];
            head = 0;
            tail = 0;
            count = 0;
            maxsize = size;
            numItems = 0;
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public Customer[] Store
        {
            get { return store; }
            set { store = value; }
        }



        public void Enqueue(Customer value)
        {
            if (IsEmpty())
            {
                head = 0;
                tail = 0;
                store[tail] = value;   //customers added at the end of the queue
                numItems++;
                count ++; //number of customers set with the first  and incremented
                
                return;
            }

            if (IsFull())  //error message if queue is full based on max size
            {
                MessageBox.Show("Queue is full. Cannot add more items.", "Queue full", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            tail = (tail + 1) % maxsize;
            store[tail] = value;
            numItems++;
            count = count + 1;

        }


        public Customer Dequeue() //error message if queue is empty based on max size
        {
            if (IsEmpty())
            {
                MessageBox.Show("Queue is empty. Cannot remove more customers.", "Queue Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            Customer headHead = store[head];
            store[head] = null; // Remove reference to the customer object
            head = (head + 1) % maxsize;
            numItems--;
            count--;
       
            return headHead;
        }

        public Customer Peek()
        {
            if (IsEmpty())
            {
                MessageBox.Show("Queue is empty.", "Peek", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            return store[head];
        }

        public bool IsEmpty()
        {
            return numItems == 0;
        }

        public bool IsFull()
        {
            return numItems == maxsize;
        }



    }
}
