import React, { Component } from "react";
import axios from "axios";

export class Home extends Component {
  static displayName = Home.name;

  constructor(props) {
    super(props);
    this.state = {
      genres: null,
      books: null,
      loading: true,
      selectedCategory: null,
      isChangingBook: false,
      changingBook: null,
      title: null,
      author: null,
      publicationYear: null,
      publisherName: null,
      isSendingRequest: false
    };
  }

  url = "https://localhost:44300/api/genre/";

  //all main function are here and in GenreController
  componentDidMount() {
    axios.get(this.url).then(({ data }) => {
      console.log(data);
      this.setState({ genres: data });
    });
  }
  //Some routing without routing, i didn't simplify and optimize the code, etc :)
  showBooks(category) {
    axios.get(this.url + category).then(({ data }) => {
      console.log(data);
      this.setState({ books: data, selectedCategory: category });
    });
  }

  deleteBook(category, bookId) {
    axios.delete(this.url + category + "/" + bookId).then(({ data }) => {
      this.setState({
        books: this.state.books.filter(book => book.id !== data.id)
      });
    });
  }

  addNewBook(category) {
    const genreID = this.state.genres.filter(genre => {
      if (genre.title === category) {
        return genre;
      }
    });
    this.setState({ isSendingRequest: true });
    axios
      .post(this.url + category, {
        title: this.state.title.toString(),
        author: this.state.author.toString(),
        publicationYear: +this.state.publicationYear,
        publisherName: this.state.publisherName.toString(),
        genreId: genreID[0].id
      })
      .then(({ data }) =>
        this.setState({
          books: [...this.state.books, data]
        })
      );
    this.setState({ isSendingRequest: false });
  }

  changeBook(category, book) {
    this.setState({ isChangingBook: false });
    axios.put(this.url + category, book).then(({ data }) =>
      this.setState({
        books: this.state.books.map(book => {
          if (book.id === data.id) return data;
          return book;
        })
      })
    );
  }

  render() {
    return (
      <div>
        <h1> Hello, world!</h1>
        <h2> Click on the title!</h2>
        <table className="table table-striped" aria-labelledby="tabelLabel">
          <thead>
            <tr>
              <th> ID </th>
              <th> Title </th>
            </tr>
          </thead>
          <tbody>
            {this.state.genres &&
              this.state.genres.map(genre => (
                <tr key={genre.id}>
                  <td>{genre.id}</td>
                  <td
                    style={{ cursor: "pointer" }}
                    onClick={() => this.showBooks(genre.title)}
                  >
                    {genre.title}
                  </td>
                </tr>
              ))}
          </tbody>
        </table>

        <div>
          <p>
            The books of <b>{this.state.selectedCategory}</b>{" "}
          </p>
        </div>

        <div style={{ marginBottom: "5px" }}>
          <p>Let add new book to this category </p>
          <span>Title: </span>
          <input
            style={{ marginRight: "10px" }}
            onChange={e => this.setState({ title: e.target.value })}
          />
          <span>Author: </span>
          <input
            style={{ marginRight: "10px" }}
            onChange={e => this.setState({ author: e.target.value })}
          />
          <span>Publication Year: </span>
          <input
            style={{ marginRight: "10px", width: "70px" }}
            onChange={e => this.setState({ publicationYear: e.target.value })}
          />
          <span>Publisher's name: </span>
          <input
            style={{ marginRight: "10px" }}
            onChange={e => this.setState({ publisherName: e.target.value })}
          />
          <button
            disabled={!this.state.selectedCategory}
            onClick={() => this.addNewBook(this.state.selectedCategory)}
          >
            Add book
          </button>
        </div>

        <table className="table table-striped" aria-labelledby="tabelLabel">
          <thead>
            <tr>
              <th> ID </th>
              <th> Title </th>
              <th> Author </th>
              <th> Publication Year </th>
              <th> Publisher's name </th>
            </tr>
          </thead>
          <tbody>
            {this.state.books &&
              this.state.books.map(book => (
                <tr key={book.id}>
                  <th>{book.id}</th>
                  <th>
                    {this.state.isChangingBook &&
                    this.state.changingBook.id === book.id ? (
                      <input
                        style={{ marginRight: "10px" }}
                        value={this.state.changingBook.title}
                        onChange={e => {
                          const val = e.target.value;
                          this.setState(prevState => ({
                            changingBook: {
                              ...prevState.changingBook,
                              title: val
                            }
                          }));
                        }}
                      />
                    ) : (
                      book.title
                    )}
                  </th>
                  <th>
                    {this.state.isChangingBook &&
                    this.state.changingBook.id === book.id ? (
                      <input
                        style={{ marginRight: "10px" }}
                        value={this.state.changingBook.author}
                        onChange={e => {
                          const val = e.target.value;
                          this.setState(prevState => ({
                            changingBook: {
                              ...prevState.changingBook,
                              author: val
                            }
                          }));
                        }}
                      />
                    ) : (
                      book.author
                    )}
                  </th>
                  <th>
                    {this.state.isChangingBook &&
                    this.state.changingBook.id === book.id ? (
                      <input
                        style={{ marginRight: "10px" }}
                        value={this.state.changingBook.publicationYear}
                        onChange={e => {
                          const val = e.target.value;
                          this.setState(prevState => ({
                            changingBook: {
                              ...prevState.changingBook,
                              publicationYear: +val
                            }
                          }));
                        }}
                      />
                    ) : (
                      book.publicationYear
                    )}
                  </th>
                  <th>
                    {this.state.isChangingBook &&
                    this.state.changingBook.id === book.id ? (
                      <input
                        style={{ marginRight: "10px" }}
                        value={this.state.changingBook.publisherName}
                        onChange={e => {
                          const val = e.target.value;
                          this.setState(prevState => ({
                            changingBook: {
                              ...prevState.changingBook,
                              publisherName: val
                            }
                          }));
                        }}
                      />
                    ) : (
                      book.publisherName
                    )}
                  </th>
                  {this.state.isChangingBook &&
                  this.state.changingBook.id === book.id ? (
                    <th>
                      <button
                        style={{ marginRight: "5px" }}
                        onClick={() =>
                          this.changeBook(
                            this.state.selectedCategory,
                            this.state.changingBook
                          )
                        }
                      >
                        Ok
                      </button>
                      <button
                        onClick={() => this.setState({ isChangingBook: false })}
                      >
                        Cancel
                      </button>
                    </th>
                  ) : (
                    <th>
                      <button
                        onClick={() =>
                          this.setState({
                            isChangingBook: true,
                            changingBook: book
                          })
                        }
                      >
                        Change
                      </button>
                    </th>
                  )}
                  <th>
                    <button
                      disabled={this.state.isChangingBook}
                      onClick={() => {
                        this.deleteBook(this.state.selectedCategory, book.id);
                      }}
                    >
                      DELETE
                    </button>
                  </th>
                </tr>
              ))}
          </tbody>
        </table>
      </div>
    );
  }
}
