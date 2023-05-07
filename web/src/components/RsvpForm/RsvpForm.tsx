import React, { useState } from "react"

interface RsvpFormProps {
  guestId: string | undefined
}

const RsvpForm = ({ guestId }: RsvpFormProps) => {

  const [rsvp, setRsvp] = useState<string | undefined>(undefined);
  const [phone, setPhone] = useState<string>("");
  const [message, setMessage] = useState<string>("");
  const [parentsWelcome, setParentsWelcome] = useState<string>("");

  return (
    <div className="card card-compact w-94 bg-base-100 shadow-xl mt-3">
      <div className="card-body items-center text-center">
        <h2 className="card-title">RSVP</h2>

        <div className="form-control  w-full max-w-xs">
          <label className="input-group">
            <span>Phone #</span>
            <input type="number" placeholder="" className="input input-bordered" />
          </label>
        </div>

        <div className="form-control w-full max-w-xs">
          <label className="label">
            <span className="label-text">RSVP</span>
          </label>
          <select className="select select-bordered">
            <option disabled selected>Pick one</option>
            <option>Accepts with Pleasure</option>
            <option>Declines with Regrets</option>
          </select>
        </div>


        <div className="form-control w-full max-w-xs">
          <label className="label">
            <span className="label-text">Parents are welcome</span>
            <span className="label-text-alt">Are you join us?</span>
          </label>
          <select className="select select-bordered">
            <option disabled selected>Pick one</option>
            <option>Yes</option>
            <option>No</option>
            <option>Maybe</option>
          </select>
        </div>

        <div className="form-control w-full max-w-xs">
          <label className="label">
            <span className="label-text">Message</span>
          </label>
          <textarea className="textarea textarea-bordered h-24" placeholder="Type here"></textarea>
        </div>

        <button className="btn w-full mt-2">Submit</button>


        

      </div>
    </div>
  )
};

export default RsvpForm;