import { ref, computed } from 'vue'
import { defineStore } from 'pinia'
import type { Book } from '@/types/types'

export const useBookStore = defineStore('bookStore', () => {
  const books = ref<Book[]>([])
  const hasFetchError = ref(false)
  const hasPostError = ref(false)

  const url = `/api/bookStore`
  const fetchBooks = async (sortBy: string = 'title'): Promise<Book[]> => {
    hasFetchError.value = false
    try {
      const response = await fetch(`${url}?sortBy=${sortBy}`)
      if (!response.ok) {
        throw new Error('Failed to fetch books')
      }

      books.value = await response.json()
      return books.value
    } catch (error) {
      console.error(error)
      hasFetchError.value = true
      return []
    }
  }

  const editBook = async (updatedBook: Book): Promise<Book | null> => {
    hasPostError.value = false

    try {
      const response = await fetch(`${url}/edit/${updatedBook.id}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(updatedBook),
      })

      if (!response.ok) {
        throw new Error('Failed to update book')
      }

      const editedBook = await response.json()
      const index = books.value.findIndex((b) => b.id === editedBook.id)
      if (index !== -1) {
        books.value[index] = editedBook
      }
      return editedBook
    } catch (error) {
      console.error(error)
      hasPostError.value = true
      return null
    }
  }

  const addBook = async (newBook: Omit<Book, 'id'>): Promise<Book | null> => {
    hasPostError.value = false
    try {
      const response = await fetch(`${url}/add`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(newBook),
      })

      if (!response.ok) {
        throw new Error('Failed to add book')
      }

      const addedBook = await response.json()
      books.value.push(addedBook)
      return addedBook
    } catch (error) {
      console.error(error)
      hasPostError.value = true
      return null
    }
  }

  const deleteBook = async (id: number): Promise<boolean> => {
    hasPostError.value = false
    try {
      const response = await fetch(`${url}/delete/${id}`, {
        method: 'DELETE',
      })

      if (!response.ok) {
        throw new Error('Failed to delete book')
      }

      books.value = books.value.filter((b) => b.id !== id)
      return true
    } catch (error) {
      console.error(error)
      hasPostError.value = true
      return false
    }
  }

  const searchBooks = async (query: string): Promise<Book[]> => {
    try {
      const response = await fetch(`${url}/search?query=${encodeURIComponent(query)}`)
      if (!response.ok) {
        throw new Error('Failed to search books')
      }

      books.value = await response.json()
      return books.value
    } catch (error) {
      console.error(error)
      hasFetchError.value = true
      return []
    }
  }

  return {
    books,
    fetchBooks,
    editBook,
    addBook,
    deleteBook,
    searchBooks,
    hasFetchError,
    hasPostError,
  }
})
