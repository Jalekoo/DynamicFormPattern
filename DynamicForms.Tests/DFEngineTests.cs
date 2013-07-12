using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForms.Components;
using DynamicForms.Engine;
using NUnit.Framework;

namespace DynamicForms.Tests
{
    [TestFixture( Category = "Engine" )]
    public class DFEngineTests
    {
        private Form SetupForm()
        {
            return FormEngine.CreateForm( "A" );
        }

        private AnswerSheet SetupSheet()
        {
            Form f = SetupForm();
            AnswerSheet a = f.FindOrCreateAnswerSheetFor( "User1" );
            return a;
        }

        [Test]
        public void CreateANewForm()
        {
            // Act
            Form f1 = SetupForm();
            Form f2 = FormEngine.CreateForm( "B" );

            // Assert
            Assert.IsNotNull( f1 );
            Assert.AreNotSame( f1, f2 );
        }

        [Test]
        public void AddQuestionToAForm()
        {
            // Arrange
            Form f = SetupForm();

            // Act
            QBinary q1 = (QBinary)f.Questions.AddANewQuestion<QBinary>( "Est-ce que c'est ma première question ?", true );
            QBinary q2 = (QBinary)f.Questions.AddANewQuestion( "DynamicForms.Components.QBinary, DynamicForms.Components", "Est-ce que c'est une seconde question ?", true );
            QBinary q3 = (QBinary)f.Questions.AddANewQuestion<QBinary>( "Est-ce que c'est une troisième question ?", true );
            QFreeText q4 = (QFreeText)f.Questions.AddANewQuestion<QFreeText>( "Est-ce que c'est une quatrième question ?", true );
            q2.Parent = q1;
            q3.Index = 0;

            q4.AllowEmptyAnswer = false;

            // Assert
            Assert.IsNotNull( q1 );
            Assert.AreSame( f, q1.Form );
            Assert.AreEqual( 1, q1.Index );
            Assert.AreEqual( q1, q2.Parent );
            Assert.AreEqual( 0, q2.Index );
            Assert.AreEqual( 0, q3.Index );
            Assert.AreEqual( 2, q4.Index );
            Assert.IsTrue( f.Questions.Contains( q1 ) );
            Assert.IsTrue( f.Questions.Contains( q2 ) );

            q3.Index = 2;
            q2.Parent = q3.Parent;
            Assert.AreEqual( 0, q1.Index );
            Assert.AreEqual( q1.Parent, q2.Parent );
            Assert.AreEqual( 3, q2.Index );
            Assert.AreEqual( 2, q3.Index );
            Assert.AreEqual( 1, q4.Index );
        }

        [Test]
        public void CreateAnAnswerSheet()
        {
            // Arrange
            Form f = SetupForm();

            // Act
            AnswerSheet a1 = f.FindOrCreateAnswerSheetFor( "User1" );
            AnswerSheet a2 = f.FindOrCreateAnswerSheetFor( "User1" );
            AnswerSheet a3 = f.FindOrCreateAnswerSheetFor( "User3" );

            // Assert
            Assert.AreSame( a1, a2 );
            Assert.AreNotEqual( a1, a3 );
            Assert.AreSame( a1.Form, f );
            Assert.AreEqual( 2, f.Sheets.Count() );
            Assert.That( f.Sheets.Any( a => a == a1 ) );
        }

        [Test]
        public void AddAnswerToAnAnswerSheet()
        {
            AnswerSheet s = SetupSheet();
            QBinary q = s.Form.Questions.AddANewQuestion<QBinary>( "Est-ce que c'est bon ?", true );
            ABase a = s.CreateAnswerFor( q );
            Assert.IsNotNull( a );
            Assert.IsInstanceOf( typeof( ABinary ), a );

            ABinary b = (ABinary)a;
            b.Answer = true;
        }

        private string SetupBinary( string path )
        {
            AnswerSheet s = SetupSheet();
            QBinary q1 = s.Form.Questions.AddANewQuestion<QBinary>( "Test 1", true );
            QBinary q2 = s.Form.Questions.AddANewQuestion<QBinary>( "Test 2", true );

            ABinary a1 = (ABinary)s.CreateAnswerFor( q1 );
            a1.Answer = true;
            ABinary a2 = (ABinary)s.CreateAnswerFor( q2 );
            a1.Answer = false;

            return FormEngine.Save( path, s.Form );
        }

        [Test]
        public void SerializeAFormToABinaryFile()
        {
            string path = SetupBinary( @"D:\Projets\_Intech\DynamicForms\bin" );

            // Assert file exists
        }

        [Test]
        public void DeserializeAFormFromABinaryFile()
        {
            string path = SetupBinary( @"D:\Projets\_Intech\DynamicForms\bin" );
            Form f = (Form)FormEngine.Load( path );

            Assert.IsNotNull( f );
        }

        private void Teardown()
        {
        }
    }
}
