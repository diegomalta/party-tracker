import React from "react";
import { LocationIcon } from "../Icons/LocationIcon";

interface AddreesProps {
  Address: string;
  Map: JSX.Element;
}

const Address = ({ Address, Map }: AddreesProps) => {
  return (
    <div className="card card-compact w-94 bg-base-100 shadow-xl mt-3">
      <div className="card-body items-center text-center">
      <h2 className="card-title font-extrabold">Dave & Buster's &#127918;</h2>
          <div>
            <LocationIcon />
            <span className="pl-2 text-lg font-bold">{Address}</span>
          </div>
      </div>
      <figure>
        {Map}
      </figure>
    </div>
  )
}

export default Address;