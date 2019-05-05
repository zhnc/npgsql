//using System;
//using System.Threading.Tasks;

//namespace Npgsql
//{
//    public class Task<TResult> : Task<TResult>
//    {
//        private TResult readFromBuffer;
//        private Task<TResult> task;
        
//        public Task(TResult readFromBuffer): base(() => readFromBuffer)
//        {
//            this.readFromBuffer = readFromBuffer;
//        }

//        public Task(Task<TResult> task):base(()=>task.Result)
//        {
//            this.task = task;
//        }

//        public bool Equals(Task<TResult> other)
//        {
//            throw new NotImplementedException();
//        }
//        public TaskAwaiter<TResult> GetAwaiter()
//        {
//            throw new NotImplementedException();

//        }

//        internal Task<object> AsTask()
//        {
//            throw new NotImplementedException();
//        }

//        //
//        // Summary:
//        //     Gets a value that indicates whether this object represents a failed operation.
//        //
//        // Returns:
//        //     true if this object represents a failed operation; otherwise, false.
//        public bool IsFaulted { get; }
//        //
//        // Summary:
//        //     Gets a value that indicates whether this object represents a successfully completed
//        //     operation.
//        //
//        // Returns:
//        //     true if this object represents a successfully completed operation; otherwise,
//        //     false.
//        public bool IsCompletedSuccessfully { get; }
//        //
//        // Summary:
//        //     Gets a value that indicates whether this object represents a completed operation.
//        //
//        // Returns:
//        //     true if this object represents a completed operation; otherwise, false.
//        public bool IsCompleted { get; }
//        //
//        // Summary:
//        //     Gets a value that indicates whether this object represents a canceled operation.
//        //
//        // Returns:
//        //     true if this object represents a canceled operation; otherwise, false.
//        public bool IsCanceled { get; }
//        //
//        // Summary:
//        //     Gets the result.
//        //
//        // Returns:
//        //     The result.
//        public TResult Result { get; }

      
//    }

//    public class TaskAwaiter<TResult> :  INotifyCompletion
//    {
//        internal TResult GetResult()
//        {
//            throw new NotImplementedException();
//        }
//        public bool IsCompleted { get; }
//        //
//        // Parameters:
//        //   continuation:
//        public void OnCompleted(Action continuation)
//        {
//            throw new NotImplementedException();

//        }
//        //
//        // Parameters:
//        //   continuation:
//        public void UnsafeOnCompleted(Action continuation)
//        {
//            throw new NotImplementedException();

//        }

//    }
//}
