using Domain;
using Domain.Models;
using BLL.Contracts;
using BLL.Implementations;
using DataAccess.Contracts;
using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;

namespace BLL.Test
{
    public class NoteServiceTests
    {
        private Mock<INoteDataAccess> fakeNoteDataAccess;
        private Note expected;

        [SetUp]
        public void SetUp()
        {
            fakeNoteDataAccess = new Mock<INoteDataAccess>();
            expected = new Note{ Id=1, Title="Title", Content="Content", Created=DateTime.Now };
        }

        [Test]
        public void TestCreateNote()
        {
            // Arrange
            fakeNoteDataAccess.Setup(x => x.Insert(It.IsAny<NoteUpdateModel>())).Returns(expected);

            // Action
            var noteService = new NoteService(fakeNoteDataAccess.Object);
            Note note = noteService.CreateNote(new NoteUpdateModel());

            // Assert
            Assert.AreEqual(note.Id, expected.Id);
            Assert.AreEqual(note.Title, expected.Title);
            Assert.AreEqual(note.Content, expected.Content);
            Assert.AreEqual(note.Created, expected.Created);
        }

        [Test]
        public void TestGetNote()
        {
            // Arrange
            fakeNoteDataAccess.Setup(x => x.Get(It.IsAny<NoteIdentityModel>())).Returns(expected);

            // Action
            var noteService = new NoteService(fakeNoteDataAccess.Object);
            Note note = noteService.GetNote(new NoteIdentityModel(1));

            // Assert
            Assert.AreEqual(note.Id, expected.Id);
            Assert.AreEqual(note.Title, expected.Title);
            Assert.AreEqual(note.Content, expected.Content);
            Assert.AreEqual(note.Created, expected.Created);
        }

        [Test]
        public void TestUpdateNote()
        {
            // Arrange
            fakeNoteDataAccess.Setup(x => x.Update(It.IsAny<NoteIdentityModel>(), It.IsAny<NoteUpdateModel>())).Returns(expected);

            // Action
            var noteService = new NoteService(fakeNoteDataAccess.Object);
            Note note = noteService.UpdateNote(new NoteIdentityModel(1), new NoteUpdateModel());

            // Assert
            Assert.AreEqual(note.Id, expected.Id);
            Assert.AreEqual(note.Title, expected.Title);
            Assert.AreEqual(note.Content, expected.Content);
            Assert.AreEqual(note.Created, expected.Created);
        }

        [Test]
        public void TestDeleteNote()
        {
            // Arrange
            fakeNoteDataAccess.Setup(x => x.Delete(It.IsAny<NoteIdentityModel>()));

            // Action
            var noteService = new NoteService(fakeNoteDataAccess.Object);
            noteService.DeleteNote(new NoteIdentityModel(1));

            // Assert
            fakeNoteDataAccess.Verify(x => x.Delete(It.IsAny<NoteIdentityModel>()), Times.Once());
        }
    }
}
