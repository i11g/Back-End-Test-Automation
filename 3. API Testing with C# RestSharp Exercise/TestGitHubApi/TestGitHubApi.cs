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
        private static int lastCreatedIssueNumber;
        private static int lastCreatedCommentId;

        [SetUp]
        public void Setup()
        {            
            client = new GitHubApiClient("https://api.github.com/repos/testnakov/", "i11g", "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");
            repo = "test-nakov-repo";
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
            var issueNumber = 9;

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
            var issueNumber = 8;

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
            
        }

        [Test, Order (6)]
        public void Test_CreateCommentOnGitHubIssue()
        {
           

         }

        [Test, Order (7)]
        public void Test_GetCommentById()
        {
            
        }


        [Test, Order (8)]
        public void Test_EditCommentOnGitHubIssue()
        {
           
        }

        [Test, Order (9)]
        public void Test_DeleteCommentOnGitHubIssue()
        {
           
        }


    }
}

