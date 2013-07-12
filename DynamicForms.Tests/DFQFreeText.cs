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
    [TestFixture( Category = "Components" )]
    public class DFQFreeText
    {
        [Test]
        public void CreateAFormWithQFreeText()
        {
            Form f = new Form( "Test" );
            QComposite n1 = f.Questions.AddANewQuestion<QComposite>( "Informations sur le programme", false );
            QFreeText q1 = n1.AddANewQuestion<QFreeText>( "Qu'aimez-vous dans ce programme ?", true );
            QFreeText q2 = (QFreeText)n1.AddANewQuestion( "DynamicForms.Components.QFreeText, DynamicForms.Components", "Qu'est-ce qui marche particulièrement bien ?", false );
            QFreeText q3 = (QFreeText)n1.AddANewQuestion( "DynamicForms.Components.QFreeText, DynamicForms.Components", "Dans quelle application l'utiliserez-vous ?", true );
            QComposite n2 = f.Questions.AddANewQuestion<QComposite>( "Informations sur l'utilisation", false );
            QFreeText q4 = n2.AddANewQuestion<QFreeText>( "Qu'est-ce qui est simple à utiliser pour vous ?", true );
            QFreeText q5 = n2.AddANewQuestion<QFreeText>( "Comment l'utilisez-vous ?", false );

            AnswerSheet toto = f.FindOrCreateAnswerSheetFor( "Toto" );
            AFreeText a1 =(AFreeText)toto.CreateAnswerFor( q1 );
            a1.AllowEmptyAnswer = false;
            a1.FreeTextAnswer = "Une réponse de test 1";
            AFreeText a2 =(AFreeText)toto.CreateAnswerFor( q2 );
            a2.AllowEmptyAnswer = true;
            a2.FreeTextAnswer = "Une réponse de test 2";
            AFreeText a3 =(AFreeText)toto.CreateAnswerFor( q3 );
            a3.AllowEmptyAnswer = false;
            a3.FreeTextAnswer = "Une réponse de test 3";
            AFreeText a4 =(AFreeText)toto.CreateAnswerFor( q4 );
            a4.AllowEmptyAnswer = true;
            a4.FreeTextAnswer = "Une réponse de test 4";
            AFreeText a5 =(AFreeText)toto.CreateAnswerFor( q5 );
            a5.AllowEmptyAnswer = false;
            a5.FreeTextAnswer = "Une réponse de test 5";
            AFreeText a6 =(AFreeText)toto.CreateAnswerFor( q5 );
            a6.AllowEmptyAnswer = false;
            a6.FreeTextAnswer = "Une réponse de test 6!";

            Assert.AreEqual( 3, n1.Children.Count );
            Assert.AreEqual( 2, n2.Children.Count );
            Assert.AreSame( q2.Parent, n1 );
            Assert.AreSame( q4.Parent, n2 );
            Assert.AreSame( toto.Answers[q1], a1 );
            Assert.AreSame( toto.Answers[q5], a6 );
        }
    }
}
