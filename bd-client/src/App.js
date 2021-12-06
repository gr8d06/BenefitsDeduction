import './App.scss';
import Header from './components/Header';
import EnrolledList from './components/EnrolledList'


function App() {
  return (
    <div className="enrolled-list container">
      <Header />
      <EnrolledList />
    </div>
  );
}

export default App;
