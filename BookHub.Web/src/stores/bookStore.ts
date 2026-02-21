import { ref } from 'vue'
import { defineStore } from 'pinia'
import  type {Book} from '@/types/types'

export const useBookStore = defineStore('books', () => {
const books = ref<Book[]>([])

  const url = `/api/bookStore`
  const fetchBooks = async (): Promise<Book[]> => {
    try {
      const response = await fetch(`${url}`)
      if (!response.ok) {
        throw new Error('Failed to fetch books')
      }

      books.value = await response.json()
      return books.value
    } catch (error) {
      console.error(error)
      return []
    }
  } 

  return { books, fetchBooks }
})
