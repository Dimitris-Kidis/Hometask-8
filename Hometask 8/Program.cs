// Hometask #8

// 1. Create methods which checks input arguments and throws exceptions ✅
// 2. Create custom exceptions and throw them ✅
// 3. Write try-catch-finally block with multiple catches ✅
// 4. Rethrow exception ✅
// 5. Add conditional compilation symbols ✅
// 6. Use debug class to write debug information to output window ✅
// 7. Declare var ✅

using System;
using System.Diagnostics;

namespace ExceptionHandingAndDebugging
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "Compilation Symbols String";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
            CompilationSymbols();


            ExceptionHandler();
        }

        public static void ExceptionHandler()
        {
            try
            {
                try
                {
                    One();
                }
                catch (InvalidOperationException e) // 1
                {
                    Console.WriteLine("Inner Exception");
                    throw e;
                }
                finally
                {
                    Debug.WriteLine("----");
                    Trace.WriteLine("TRRRRRRACE");
                    Four();
                }
                //Four();
            }
            catch (UnexpectedException e) // 4
            {
                Debug.WriteLine("Check");
                Console.WriteLine($"Catched {nameof(CustomException)} with details: {e.Message}");
            }
#if DEBUG_EXCEPTION_PART
            catch (CustomException e) // 3
            {
                Console.WriteLine($"Catched {nameof(UnexpectedException)} with details: {e.Message}");
            }
#elif RELEASE_EXCEPTION_PART
        catch (CustomException e) // 3
            {
                Console.WriteLine($"Catched {nameof(UnexpectedException)} with details: {e.Message}");
            }
#endif
            catch (Exception e)// when (e is InvalidOperationException | e is SystemException) // 1 || 2
            {
                Console.WriteLine($"Catched {e.GetType()} with details: {e.Message}");
            }
            finally
            {
                Console.WriteLine("FINALLY!!!");
            }
        }

        public static void One()
        {
            Console.WriteLine("One");
            throw new InvalidOperationException("Message InvalidOperationException");
        }


        public static void Two()
        {
            Console.WriteLine("Two");
            throw new SystemException("Message SystemException");
        }


        public static void Three()
        {
            Console.WriteLine("Three");
            throw new UnexpectedException("Message UnexpectedException");
        }

        public static void Four()
        {
            Console.WriteLine("Four");
            throw new CustomException("Message CustomException");
        }

        public static void CompilationSymbols()
        {
#if DEBUG
            var count = 200;
            Console.WriteLine("DEBUG. Count = " + count);
#elif RELEASE
            var count = 200;
            Console.WriteLine("Release. Count = " + count);
#endif
        }
    }

    public class UnexpectedException : Exception
    {
        public UnexpectedException() : base() { }
        public UnexpectedException(string? message) : base(message) { }
        public UnexpectedException(string? message, Exception? innerException) : base(message, innerException) { }
    }

    public class CustomException : Exception
    {
        public CustomException() : base() { }
        public CustomException(string? message) : base(message) { }
        public CustomException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}