// 代码生成时间: 2025-10-09 02:47:24
 * Author: [Your Name]
 * Date: [Today's Date]
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartQuestionBankSystem
{
    // Represents a single question with associated metadata
# FIXME: 处理边界情况
    public class Question
    {
# TODO: 优化性能
        public int Id { get; set; }
        public string Text { get; set; }
        public List<string> Options { get; set; } = new List<string>();
        public int CorrectAnswerIndex { get; set; }
        public string Category { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
# 扩展功能模块
    }

    // Manages the question bank
    public class QuestionBank
    {
        private List<Question> questions;

        public QuestionBank()
        {
            questions = new List<Question>();
        }

        // Adds a new question to the bank
        public void AddQuestion(Question question)
        {
            if (question == null) throw new ArgumentNullException(nameof(question));
            questions.Add(question);
        }

        // Retrieves a random question from the bank
        public Question GetRandomQuestion()
        {
            if (!questions.Any()) throw new InvalidOperationException("The question bank is empty.");
            Random rand = new Random();
            int index = rand.Next(questions.Count);
            return questions[index];
        }
# 优化算法效率

        // Retrieves questions by category
        public List<Question> GetQuestionsByCategory(string category)
# TODO: 优化性能
        {
            if (string.IsNullOrEmpty(category)) throw new ArgumentException("Category cannot be null or empty.", nameof(category));
            return questions.Where(q => q.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
# 改进用户体验
        }

        // Updates a question in the bank
        public bool UpdateQuestion(int id, Question updatedQuestion)
        {
            if (updatedQuestion == null) throw new ArgumentNullException(nameof(updatedQuestion));
            var question = questions.FirstOrDefault(q => q.Id == id);
            if (question == null) return false;
            question.Text = updatedQuestion.Text;
            question.Options = updatedQuestion.Options;
            question.CorrectAnswerIndex = updatedQuestion.CorrectAnswerIndex;
            question.Category = updatedQuestion.Category;
            return true;
# NOTE: 重要实现细节
        }

        // Deletes a question from the bank
        public bool DeleteQuestion(int id)
        {
            var question = questions.FirstOrDefault(q => q.Id == id);
            if (question == null) return false;
            questions.Remove(question);
            return true;
        }
    }
}
