using RestSharpServices;
using System.Net;
using System.Reflection.Emit;
using System.Text.Json;
using RestSharp;
using RestSharp.Authenticators;
using NUnit.Framework.Internal;
using RestSharpServices.Models;
using System;

namespace TestGitHubApi
{
    public class TestGitHubApi
    {
        private GitHubApiClient client;
        private static string repo;
        private static long lastCreatedIssueNumber;
        private static long lastCreatedCommentId;

        [SetUp]
        public void Setup()
        {            
            client = new GitHubApiClient("https://api.github.com/repos/i11g/", "i11g", "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");
            repo = "New-Extra";
        }


        [Test, Order (1)]
        public void Test_GetAllIssuesFromARepo()
        {
            //Act 

            var issues = client.GetAllIssues(repo);

            //Assert

            Assert.That(issues, Has.Count.GreaterThan(0),"There should be more than one issue");
            foreach(var issue in issues)
            {
                Assert.That(issue.Id, Is.GreaterThan(0));
                Assert.That(issue.Number, Is.GreaterThan(0));
                Assert.That(issue.Title, Is.Not.Empty);
            }
            
        }

        [Test, Order (2)]
        public void Test_GetIssueByValidNumber()
        {
            //Arrange
            var issueNumber = 1;
            
            //Act
            var issue=client.GetIssueByNumber(repo, issueNumber);

            //Assert

            Assert.That(issue, Is.Not.Null);
            Assert.That(issue.Id, Is.GreaterThan(0));
            Assert.That(issue.Number, Is.EqualTo(issueNumber));
        }
        
        [Test, Order (3)]
        public void Test_GetAllLabelsForIssue()
        {
            //Arrange
            var issueNumber = 1;

            //Act
            var labels=client.GetAllLabelsForIssue(repo, issueNumber);

            //Assert 

            Assert.That(labels.Count, Is.GreaterThan(0));

            foreach (var label in labels)
            {
                Assert.That(label.Id, Is.GreaterThan(0));
                Assert.That(label.Name, Is.Not.Empty);

                Console.WriteLine("Label:" + label.Id + " - Name: " + label.Name);
            } 
        }

        [Test, Order (4)]
        public void Test_GetAllCommentsForIssue()
        {
            //Arrange
            var issueNumber = 2;

            //Act
            var comments=client.GetAllCommentsForIssue(repo,issueNumber);

            //Assert 

            Assert.That(comments.Count, Is.GreaterThan(0));
            foreach(var comment in comments)
            {
                Assert.That(comment.Id, Is.GreaterThan(0));
                Assert.That(comment.Body, Is.Not.Null);

                Console.WriteLine("Comment:" + comment.Id + " - Body: " + comment.Body);
            }
           
        }

        [Test, Order(5)]
        public void Test_CreateGitHubIssue()
        {
            //Arrange
            string title = "New Issue Created";
            string body = "The issue is sucsesfully created";
            //Act
            var issue = client.CreateIssue(repo, title, body);
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(issue, Is.Not.Null);
                Assert.That(issue.Id, Is.GreaterThan(0));
                Assert.That(issue.Number, Is.GreaterThan(0));
                Assert.That(issue.Title, Is.EqualTo(title));

            });
            Console.WriteLine(issue.Number);
            lastCreatedIssueNumber = issue.Number;


        }

        [Test, Order (6)]
        public void Test_CreateCommentOnGitHubIssue()
        {
            //Arrange
            string body = "Changed";
            long issueNumber = lastCreatedIssueNumber;

            //Act
            var comment = client.CreateCommentOnGitHubIssue(repo, issueNumber,  body);

            //Assert 

            Assert.That(comment, Is.Not.Null);
            //Assert.That(comment.Id, Is.GreaterThan(0));
            Assert.That(comment.Body, Is.EqualTo(body));
            Console.WriteLine(comment.Id);
            lastCreatedCommentId = comment.Id;

        }

        [Test, Order (7)]
        public void Test_GetCommentById()
        {
            //Arrange
            long id = lastCreatedCommentId;
            //Act
            var comment=client.GetCommentById(repo, id);
            //Assert
            Assert.That(comment, Is.Not.Null);
            Assert.That(comment.Id, Is.EqualTo(id));
        }


        [Test, Order (8)]
        public void Test_EditCommentOnGitHubIssue()
        { 
            //Arrange
            long id= lastCreatedCommentId;
            string body = "Edited";
            //Act
            var editComment=client.EditCommentOnGitHubIssue(repo,id, body);
            //Assert
            Assert.That(editComment, Is.Not.Null);
            Assert.That(editComment.Body, Is.EqualTo(body));
            Assert.That(editComment.Id, Is.EqualTo(id));
           
        }

        [Test, Order (9)]
        public void Test_DeleteCommentOnGitHubIssue()
        {   
            //Arrange
            long id= lastCreatedCommentId;
            //Act
            var result = client.DeleteCommentOnGitHubIssue(repo, id);
            //Assert
            Assert.That(result, Is.True);
            Assert.True(result);
           
        }


    }
}

