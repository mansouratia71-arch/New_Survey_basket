using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Survey_Basket.Migrations
{
    /// <inheritdoc />
    public partial class addvote2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vote_AspNetUsers_userId",
                table: "Vote");

            migrationBuilder.DropForeignKey(
                name: "FK_Vote_Polls_pollid",
                table: "Vote");

            migrationBuilder.DropForeignKey(
                name: "FK_VoteAnswer_Answers_AnswerId",
                table: "VoteAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_VoteAnswer_Questions_QuestionId",
                table: "VoteAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_VoteAnswer_Vote_voteId",
                table: "VoteAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VoteAnswer",
                table: "VoteAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vote",
                table: "Vote");

            migrationBuilder.RenameTable(
                name: "VoteAnswer",
                newName: "VoteAnswers");

            migrationBuilder.RenameTable(
                name: "Vote",
                newName: "Votes");

            migrationBuilder.RenameIndex(
                name: "IX_VoteAnswer_voteId_QuestionId",
                table: "VoteAnswers",
                newName: "IX_VoteAnswers_voteId_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_VoteAnswer_QuestionId",
                table: "VoteAnswers",
                newName: "IX_VoteAnswers_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_VoteAnswer_AnswerId",
                table: "VoteAnswers",
                newName: "IX_VoteAnswers_AnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_Vote_userId",
                table: "Votes",
                newName: "IX_Votes_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Vote_pollid_userId",
                table: "Votes",
                newName: "IX_Votes_pollid_userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VoteAnswers",
                table: "VoteAnswers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Votes",
                table: "Votes",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_VoteAnswers_Answers_AnswerId",
                table: "VoteAnswers",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VoteAnswers_Questions_QuestionId",
                table: "VoteAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VoteAnswers_Votes_voteId",
                table: "VoteAnswers",
                column: "voteId",
                principalTable: "Votes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_AspNetUsers_userId",
                table: "Votes",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Polls_pollid",
                table: "Votes",
                column: "pollid",
                principalTable: "Polls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoteAnswers_Answers_AnswerId",
                table: "VoteAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_VoteAnswers_Questions_QuestionId",
                table: "VoteAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_VoteAnswers_Votes_voteId",
                table: "VoteAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_AspNetUsers_userId",
                table: "Votes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Polls_pollid",
                table: "Votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Votes",
                table: "Votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VoteAnswers",
                table: "VoteAnswers");

            migrationBuilder.RenameTable(
                name: "Votes",
                newName: "Vote");

            migrationBuilder.RenameTable(
                name: "VoteAnswers",
                newName: "VoteAnswer");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_userId",
                table: "Vote",
                newName: "IX_Vote_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_pollid_userId",
                table: "Vote",
                newName: "IX_Vote_pollid_userId");

            migrationBuilder.RenameIndex(
                name: "IX_VoteAnswers_voteId_QuestionId",
                table: "VoteAnswer",
                newName: "IX_VoteAnswer_voteId_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_VoteAnswers_QuestionId",
                table: "VoteAnswer",
                newName: "IX_VoteAnswer_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_VoteAnswers_AnswerId",
                table: "VoteAnswer",
                newName: "IX_VoteAnswer_AnswerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vote",
                table: "Vote",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VoteAnswer",
                table: "VoteAnswer",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_AspNetUsers_userId",
                table: "Vote",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_Polls_pollid",
                table: "Vote",
                column: "pollid",
                principalTable: "Polls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VoteAnswer_Answers_AnswerId",
                table: "VoteAnswer",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VoteAnswer_Questions_QuestionId",
                table: "VoteAnswer",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VoteAnswer_Vote_voteId",
                table: "VoteAnswer",
                column: "voteId",
                principalTable: "Vote",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
