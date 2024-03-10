import os
import math
from collections import Counter
import re

def preprocess_text(text):
    # Функція для попередньої обробки тексту: розбиття на слова, видалення розділових знаків, перетворення на малі літери
    words = re.findall(r'\w+', text.lower())
    return words

def calculate_tf(document):
    # Розрахунок TF для документу
    word_counts = Counter(document)
    total_words = len(document)
    tf = {word: word_counts[word] / total_words for word in word_counts}
    return tf

def calculate_idf(documents):
    # Розрахунок IDF для корпусу документів
    N = len(documents)
    idf = {}
    all_words = set(word for doc in documents for word in doc)
    for word in all_words:
        n = sum(1 for doc in documents if word in doc)
        idf[word] = math.log(N / n)
    return idf

def calculate_cosine_similarity(query, document, idf):
    # Розрахунок косинусної подібності між запитом та документом
    query_vector = {word: query.count(word) * idf.get(word, 0) for word in query}
    doc_vector = {word: document.count(word) * idf.get(word, 0) for word in document}

    dot_product = sum(query_vector[word] * doc_vector[word] for word in query_vector)
    query_norm = math.sqrt(sum(value ** 2 for value in query_vector.values()))
    doc_norm = math.sqrt(sum(value ** 2 for value in doc_vector.values()))

    if query_norm != 0 and doc_norm != 0:
        cosine_similarity = dot_product / (query_norm * doc_norm)
    else:
        cosine_similarity = 0

    return cosine_similarity

def read_documents_from_directory(directory):
    # Функція для зчитування документів з вказаної директорії
    documents = []
    for filename in os.listdir(directory):
        with open(os.path.join(directory, filename), 'r', encoding='utf-8') as file:
            text = file.read()
            preprocessed_text = preprocess_text(text)
            documents.append(preprocessed_text)
    return documents

def main():
    # Основна функція
    directory = input("Введіть шлях до директорії з текстовими документами: ")
    documents = read_documents_from_directory(directory)

    idf = calculate_idf(documents)

    while True:
        query = input("Введіть пошуковий запит (або 'вийти' для завершення): ")
        if query.lower() == 'вийти':
            break

        preprocessed_query = preprocess_text(query)
        similarities = []
        for idx, document in enumerate(documents):
            cosine_similarity = calculate_cosine_similarity(preprocessed_query, document, idf)
            similarities.append((idx, cosine_similarity))

        similarities.sort(key=lambda x: x[1], reverse=True)

        for idx, similarity in similarities:
            print(f"Документ {idx + 1}: Подібність = {similarity}")

if __name__ == "__main__":
    main()
