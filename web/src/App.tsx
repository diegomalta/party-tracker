import React from 'react';
import GuestEventView from './views/GuestEventView/GuestEventView';
import { BrowserRouter, Routes, Route } from 'react-router-dom';

function App() {

  const Rsvp = <><div className='container mx-auto px-4 min-h-screen'>
    <GuestEventView />
  </div>
    <footer className="footer footer-center p-4 bg-base-300 text-base-content">
      <div>
        <p>All right reserved by Malta-Castellanos Family</p>
      </div>
    </footer></>
    ;

  return (
    <BrowserRouter>
      <Routes>
        <Route path='/:guestId' element={Rsvp} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
