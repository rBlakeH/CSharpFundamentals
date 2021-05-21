using System;
using Xunit;

namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTest
    {
        int count = 0;


        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncCount;
            var result = log("Hello!");
            Assert.Equal(3, count);
        }

        string ReturnMessage(string Message)
        {
            count++;
            return Message;
        }
        string IncCount(string Message)
        {
            count++;
            return Message.ToUpper();
        }



        [Fact]
        public void StringLikeValue()
        {
            string name = "Blake";
            var upper = MakUppercase(name);
            Assert.Equal("BLAKE", upper);
        }
        private string MakUppercase(string para)
        {
            return para.ToUpper();
        }


        [Fact]
        public void IntByRef()
        {
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(42, x);
        }
        public void SetInt(ref int z)
        {
            z = 42;
        }
        public int GetInt()
        {
            return 3;
        }

        [Fact]
         public void BookRenameByRef()
        {
            var book1 = GetBook("Book 1"); 
            GetBookSetNameRef(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name); 
            
        }
        private void GetBookSetNameRef(ref Book book, string name)
        {
            book = new Book(name);
                            
        }


         [Fact]
         public void BookRenameValue()
        {
            var book1 = GetBook("Book 1"); 
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name); 
            
        }
        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
                            
        }


        [Fact]
         public void BookRenameRef()
        {
            var book1 = GetBook("Book 1"); 
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name); 
            
        }
        private void SetName(Book book, string name)
        {
            book.Name = name;                
        }


        [Fact]
        public void BookDiffObjects()
        {
            var book1 = GetBook("Book 1"); 
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name); 
            Assert.Equal("Book 2", book2.Name); 
            
        }

        [Fact]
        public void BookSameObjects()
        {
            var book1 = GetBook("Book 1"); 
            var book2 = book1;

            Assert.Same(book1, book2);
            
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
