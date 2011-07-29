﻿using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSScriptControl;   

namespace NaboursCRM.UI.Javascript.Tests
{
    public class JavascriptTestHelper : IDisposable
    {
        private ScriptControl _sc; 
        private TestContext _context;           
        /// <summary>        
        /// You need to use this helper with Unit Tests and not         
        /// Basic Unit Tests because you need a Test Context         
        /// </summary>         
        /// <param name="testContext">Unit Test Test Context</param>         
        public JavascriptTestHelper(TestContext testContext)
        {
            if (testContext == null)
            {
                throw new ArgumentNullException("TestContext");
            }
            _context = testContext;
            _sc = new ScriptControl();
            _sc.Language = "JScript";
            _sc.AllowUI = false;
        }

        /// <summary>         
        /// Load the contents of a JavaScript file into the          
        /// Script Engine.         
        /// </summary>         
        /// <param name="path">Path to JavaScript file</param>         
        public void LoadFile(string path)
        {
            var fileContents = File.ReadAllText(path);
            _sc.AddCode(fileContents);
        }

        /// <summary>         
        /// Pass the path of the test that you want to execute.         
        /// </summary>         
        /// <param name="testMethodName">JavaScript function name</param>         
        public void ExecuteTest(string testMethodName)
        {
            dynamic result = null;
            try
            {
                result = _sc.Run(testMethodName, new object[] {});
            }
            catch
            {
                var error = ((IScriptControl) _sc).Error;
                if (error != null)
                {
                    var description = error.Description;
                    var line = error.Line;
                    var column = error.Column;
                    var text = error.Text;
                    var source = error.Source;
                    if (_context != null)
                    {
                        var details = String.Format("{0} \r\nLine: {1} Column: {2}", source, line, column);
                        _context.WriteLine(details);
                    }
                }
                throw new AssertFailedException(error.Description);
            }
        }

        public void Dispose()
        {
            _sc = null;
        }
    }
}
