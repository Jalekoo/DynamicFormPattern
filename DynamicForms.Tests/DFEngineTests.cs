using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForms.Engine;
using NUnit.Framework;

namespace DynamicForms.Tests
{
    [TestFixture]
    public class DFEngineTests
    {
        private void Setup()
        {
        }

        [Test]
        public Form CreateANewForm()
        {
            // Act
            Form f = new Form( "A" );
            Form f2 = new Form( "B" );

            // Assert
            Assert.IsNotNull( f );
            Assert.AreNotEqual( f, f2 );

            return f;
        }

        [Test]
        public void AddQuestionToAForm()
        {
            // Arrange
            Form f = CreateANewForm();

            // Act
            QBinary q = f.AddANewQuestion( typeof( QBinary ), "Est-ce que c'est ma première question ?", true );

            // Assert
            Assert.IsNotNull( q );
            Assert.AreEqual( 1, f.Questions.Count() );
        }

        [Test]
        public AnswerSheet CreateAnAnswerSheet()
        {
            // Arrange
            Form f = CreateANewForm();

            // Act
            AnswerSheet a1 = f.FindOrCreateAnswerSheet( "User1" );
            AnswerSheet a2 = f.FindOrCreateAnswerSheet( "User1" );
            AnswerSheet a3 = f.FindOrCreateAnswerSheet( "User3" );

            // Assert
            Assert.AreEqual( a1, a2 );
            Assert.AreNotEqual( a1, a3 );
            Assert.AreEqual( a1.Form, f );
            Assert.AreEqual( 1, f.Sheets.Count() );
            Assert.That( f.Sheets.Any( a => a == a1 ) );

            return a1;
        }

        [Test]
        public void AddAnswerToAnAnswerSheet()
        {
            AnswerSheet s = CreateAnAnswerSheet();
            QBinary q = s.Form.AddANewQuestion( typeof( QBinary ), "Est-ce que c'est bon ?", true );
            ABase a = s.FindOrCreateAnswerFor( q );
            Assert.IsNotNull( a );
            Assert.IsInstanceOf( typeof( ABinary ), a );

            ABinary b = (ABinary)a;
            b.Answer = true;
        }

        private void Teardown()
        {
        }
    }
}
